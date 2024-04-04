using GreedySnake.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Game
{
    internal class GameScene : ISceneUpdate
    {
        Map map;
        Snake snake;
        Food food;

        //计时器
        int updateIndex = 0;
        //延迟
        int delay = 5000;
        public GameScene()
        {
            map = new Map();
            snake = new Snake(10,9);
            food = new Food(snake);
        }
        public void Update()
        {
            if (updateIndex % delay == 0) 
            {
                map.Draw();
                food.Draw();
                snake.Move();
                snake.Draw();

                if (snake.CheckGameOver(map))
                {
                    Game.ChangeScene(E_SceneType.End);
                }

                snake.CheckEatFood(food);

                updateIndex = 0;
            }
            updateIndex++;

            //检测键盘是否被激活
            if( Console.KeyAvailable )
            {
                //检测移动方向
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDirction(E_MoveDirection.Up);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDirction(E_MoveDirection.Left);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDirction(E_MoveDirection.Down);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDirction(E_MoveDirection.Right);
                        break;
                }
            }
        }
    }
}
