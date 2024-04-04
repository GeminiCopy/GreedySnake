using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Game
{
    abstract internal class BeginOrEndBaseScene : ISceneUpdate
    {
        protected int nowChooseIndex = 0;
        protected string strTitle = "啊对对对S";
        protected string strFirstLine;
        protected string strSecondLine = "结束游戏";

        public abstract void EnterNextScene();
        public void Update()
        {
            //开始和结束场景的 游戏逻辑
            //选择当前的选项 然后 监听 键盘输入 wsj

            Console.ForegroundColor = ConsoleColor.White;
            //显示标题
            Console.SetCursorPosition(Game.w/2 - strTitle.Length, 5 );
            Console.Write( strTitle );
            //显示下方选项
            Console.SetCursorPosition(Game.w / 2 - strFirstLine.Length, 8);
            Console.ForegroundColor = nowChooseIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write( strFirstLine );

            Console.SetCursorPosition(Game.w / 2 - strSecondLine.Length, 11);
            Console.ForegroundColor = nowChooseIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write( strSecondLine );
            //检测输入
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    nowChooseIndex--;
                    if( nowChooseIndex < 0 )
                    {
                        nowChooseIndex = 1;
                    }
                    break;
                case ConsoleKey.S:
                    nowChooseIndex++;
                    if(nowChooseIndex > 1)
                    {
                        nowChooseIndex = 0;
                    }
                    break;
                case ConsoleKey.J:
                    EnterNextScene();
                    break;
            }
        }
    }
}
