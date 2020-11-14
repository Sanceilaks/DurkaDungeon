using System;
using System.Collections.Generic;
using System.Text;
using DurkaDungeon.Core.Types;
using DurkaDungeon.Core.Entitys;

namespace DurkaDungeon.Core.Map
{
    class GameMap
    {
        private IMap Map;
        private LocalPlayer localPlayer;
        private List<BaseEntity> entities;

        public LocalPlayer GetLocalPlayer()
        {
            return localPlayer;
        }

        public GameMap(IMap lowLvlMap)
        {
            Map = lowLvlMap;

            entities = new List<BaseEntity>();
        }

        public void Init()
        {
            localPlayer = new LocalPlayer(new Position(1, 1));

            AddEntity(localPlayer);
        }

        public IMap GetMap()
        {
            return Map;
        }

        public void Draw()
        {
            /*for (int i = 0; i <= Map.GetSize().GetSquare(); i++)
            {*/
            for (int g = 1; g < Map.GetSize().Y; g++) // y
            {
                for (int j = 1; j < Map.GetSize().X; j++) //x
                {
                    BaseEntity entity = GetEntity(new Position(j, g));

                    if (entity != null)
                        if (localPlayer.Equals(entity))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(entity.DrawChar);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            Console.Write(entity.DrawChar);
                    else
                        Console.Write("*");
                }

                Console.Write("\n");

                //i += Map.GetSize().X;
            }
            //}
        }

        public void AddEntity(BaseEntity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(BaseEntity entity)
        {
            entities.Remove(entity);
        }

        public BaseEntity GetEntity(string id)
        {
            foreach (var i in entities)
            {
                if (i.Id == id)
                    return i;
            }

            return null;
        }

        public BaseEntity GetEntity(Position position)
        {
            foreach (var i in entities)
            {
                if (i.Position.Equals(position))
                    return i;
            }

            return null;
        }
    }
}
