using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreedySnake.Draw;

namespace GreedySnake.GameObject
{

    abstract class GameObject : IDraw
    {
        public Position pos;
        //可以继承接口后把接口中的行为变成抽象行为
        //供子类去实现 因为是抽象行为 所以子类必须实现
        public abstract void Draw();
    }
}
