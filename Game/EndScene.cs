using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Game
{
    internal class EndScene : BeginOrEndBaseScene
    {
        public EndScene()
        {
            strTitle = "你死了";
            strFirstLine = "回到开始界面";
        }
        public override void EnterNextScene()
        {
            if (nowChooseIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Begin);
            }
            else if (nowChooseIndex == 1)
            {
                //退出
                Environment.Exit(0);
            }
        }
    }
}
