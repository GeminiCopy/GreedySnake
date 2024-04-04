using GreedySnake.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.GameObject
{
    enum E_MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
    }
    internal class Snake : IDraw
    {
        SnakeBody[] bodies;

        //记录当前蛇的长度
        public int nowNum;
        //当前移动方向
        E_MoveDirection moveDirection;
        public Snake(int x,int y)
        {
            //粗暴地申明200个空间
            bodies = new SnakeBody[200];
            bodies[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            nowNum = 1;
            //默认开始移动方向
            moveDirection = E_MoveDirection.Right;
        }
        public void Draw()
        {
            for(int i = 0; i < nowNum; i++)
            {
                bodies[i].Draw();
            }
        }

        public void Move()
        {
            //移动前擦除尾巴的格子
            Console.SetCursorPosition(bodies[nowNum - 1].pos.x, bodies[nowNum - 1].pos.y);
            Console.Write("  ");

            //蛇头移动之前 每个蛇身的位置变为前一个身子的位置
            for(int i = nowNum - 1; i > 0 ; i--)
            {
                bodies[i].pos = bodies[i - 1].pos;
            }

            //移动
            switch(moveDirection)
            {
                case E_MoveDirection.Left:
                    bodies[0].pos.x-=2;
                    break;
                case E_MoveDirection.Right:
                    bodies[0].pos.x += 2;
                    break;
                case E_MoveDirection.Up:
                    bodies[0].pos.y--;
                    break;
                case E_MoveDirection.Down:
                    bodies[0].pos.y++;
                    break;
            }
        }
        //改变方向
        public void ChangeDirction(E_MoveDirection direction)
        {
            if (direction == this.moveDirection) return;
            //只有头部 随便移动
            if (nowNum == 1)
            {
                moveDirection = direction;
            }
            //有身体时 不能往身体方向移动
            else
            {
                if (moveDirection == E_MoveDirection.Up && direction == E_MoveDirection.Down) return;
                if (moveDirection == E_MoveDirection.Down && direction == E_MoveDirection.Up) return;
                if (moveDirection == E_MoveDirection.Left && direction == E_MoveDirection.Right) return;
                if (moveDirection == E_MoveDirection.Right && direction == E_MoveDirection.Left) return;
                moveDirection = direction;
            }
        }
        public bool CheckGameOver(Map map)
        {
            //是否和墙体位置重合
            for(int i = 0; i < map.walls.Length; i++)
            {
                if (bodies[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }
            //是否和身体重合
            for(int i = 1; i < nowNum; i++)
            {
                if (bodies[0].pos == bodies[i].pos)
                {
                    return true;
                }
            }
            return false;
        }
        //通过传入一个位置 来判断这个位置 是不是和蛇重合
        public bool CheckSamePosition(Position p)
        {
            for (int i = 0;i<nowNum;i++)
            {
                if (bodies[i].pos == p) return true;
            }
            return false;
        }
        //吃食物
        public void CheckEatFood(Food food)
        {
            if(bodies[0].pos == food.pos)
            {
                food.RandomPosition(this);
                AddBody();
            }
        }
        //增长身体
        public void AddBody()
        {
            bodies[nowNum] = new SnakeBody(E_SnakeBody_Type.Body, bodies[nowNum -1].pos.x, bodies[nowNum - 1].pos.y);
            nowNum++;
        }
    }
}
