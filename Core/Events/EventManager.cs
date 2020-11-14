using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Events
{
    class EventManager
    {
        private DurkaDungeon.Core.Map.GameMap GameMap;

        public EventManager()
        {

        }

        public EventManager(DurkaDungeon.Core.Map.GameMap gameMap)
        {
            GameMap = gameMap;
        }

        public void Pull()
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.RightArrow)
                GameMap.GetLocalPlayer().Move(new Types.Position(1, 0));

            if (key.Key == ConsoleKey.LeftArrow)
                GameMap.GetLocalPlayer().Move(new Types.Position(-1, 0));

            if (key.Key == ConsoleKey.UpArrow)
                GameMap.GetLocalPlayer().Move(new Types.Position(0, -1));

            if (key.Key == ConsoleKey.DownArrow)
                GameMap.GetLocalPlayer().Move(new Types.Position(0, 1));
        }


    }
}
