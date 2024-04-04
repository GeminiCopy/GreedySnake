using GreedySnake.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.GameObject
{
    internal class Food : GameObject
    {
        public Food(Snake snake)
        {
            RandomPosition(snake);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("食");
        }
        //随机位置
        public void RandomPosition(Snake snake)
        {
            Random r= new Random();
            int x = r.Next(2, Game.Game.w / 2 - 1) * 2;
            int y = r.Next(1, Game.Game.h - 4);
            pos = new Position(x,y);
            if (snake.CheckSamePosition(pos))
            {
                RandomPosition(snake);
            }
        }
    }
}
