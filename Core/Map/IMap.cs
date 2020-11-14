using System;
using System.Collections.Generic;
using System.Text;
using DurkaDungeon.Core.Types;

namespace DurkaDungeon.Core.Map
{
    interface IMap
    {
        bool isGenerated();

        bool Generate(int mapSizeX, int mapSizeY);
        IPoint GetPoint(int x, int y);

        IPoint GetPoint(string id);
        void SetPoint(IPoint oldPoint, IPoint newPoint);

        Size GetSize();
    }



    class BaseMap : IMap
    {
        private bool isGenerated = false;
        private List<IPoint> points;
        private Size size;

        bool IMap.Generate(int mapSizeX, int mapSizeY)
        {
            points = new List<IPoint>();
            size = new Size(mapSizeX, mapSizeY);

            int mapSize = mapSizeX * mapSizeY; //   S = x * y

            int x; int y = 1; int last_n = 0;
            for (int i = 0; i <= mapSize; i++)
            {
                x = i;
                int n = x / mapSizeX + 1;
                if (x > mapSizeX)
                {
                    do
                    {
                        x -= mapSizeX;
                    } while (x > mapSizeX);

                    if (n > last_n)
                    {
                        y++;
                        last_n = n;
                    }
                }

                try
                {
                    points.Add(new Point(new Position() { X = x, Y = y }));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}. Skip point!");
                }
                
            }

            
            isGenerated = true;
            return isGenerated;
        }

        IPoint IMap.GetPoint(int x, int y)
        {
            Position position = new Position() { X = x, Y = y };

            foreach (var i in points)
            {
                if (i.GetPosition() == position)
                    return i;
            }

            return null;
        }

        IPoint IMap.GetPoint(string id)
        {
            foreach (var i in points)
            {
                if (i.GetID().ToLower() == id.ToLower())
                    return i;
            }

            return null;
        }

        Size IMap.GetSize()
        {
            return size;
        }

        bool IMap.isGenerated()
        {
            return isGenerated;
        }

        void IMap.SetPoint(IPoint oldPoint, IPoint newPoint)
        {
            int index = 0;
            foreach (var i in points)
            {
                if (i.GetID() == oldPoint.GetID() && i.GetPosition() == oldPoint.GetPosition())
                    break;

                index++;
            }

            points[index] = newPoint;
        }
    }
}
