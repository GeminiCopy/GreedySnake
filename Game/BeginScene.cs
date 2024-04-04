using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Game
{
    internal class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene()
        {
            strTitle = "贪吃蛇";
            strFirstLine = "开始游戏";
        }
        public override void EnterNextScene()
        {
            if (nowChooseIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else if (nowChooseIndex == 1)
            {
                //退出
                Environment.Exit(0);
            }
        }
    }
}
