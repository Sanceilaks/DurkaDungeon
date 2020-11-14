using System;
using System.Text.Json;
using DurkaDungeon.Core;


namespace DurkaDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            IBootstrap bootstrap = new Bootstrap();

            bootstrap.Init();

            Core.Map.GameMap gameMap = new Core.Map.GameMap(bootstrap.GetMap());

            gameMap.Init();


            while (true)
            {
                gameMap.Draw();

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow)
                    gameMap.GetLocalPlayer().Position.X += 1;

                Console.Clear();
            }
            

        }
    }
}
