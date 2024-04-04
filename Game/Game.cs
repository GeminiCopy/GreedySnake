using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Game
{
    enum E_SceneType
    {
        Begin,
        Game,
        End,
    }
    internal class Game
    {
        //游戏窗口宽高
        public const int w = 80;
        public const int h = 20;
        //当前选中的场景
        public static ISceneUpdate nowScene;

        public Game()
        {
            //光标隐藏
            Console.CursorVisible = false;
            //设置窗口大小
            Console.SetWindowSize(w, h);
            //设置缓冲区大小
            Console.SetBufferSize(w, h);

            ChangeScene(E_SceneType.Begin);
        }

        public void Start()
        {
            while (true)
            {
                if (nowScene != null) 
                {
                    nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            //消除上一个场景的绘制内容
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }
        }
    }
}
