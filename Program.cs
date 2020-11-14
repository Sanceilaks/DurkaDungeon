using System;
using System.Text.Json;
using DurkaDungeon.Core;
using DurkaDungeon.Core.Events;

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

            EventManager eventManager = new EventManager(gameMap);

            while (true)
            {
                gameMap.Draw();

                eventManager.Pull();

                Console.Clear();
            }
        }
    }
}
