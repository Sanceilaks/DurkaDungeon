using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Map
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    interface IPoint
    {
        //string id { get; set; }

        string GetID();

        Position GetPosition();

        void SetPosition(Position pos);

        
    }

    class Point : IPoint
    {
        private string id;
        private Position position;
        static string last;

        //string IPoint.id { get => id; set => id = value; }

        public Point()
        {

        }

        public Point(Position pos)
        {
            Random random = new Random(1488 * 1488 + Environment.TickCount + (pos.X - (pos.Y * 2 - pos.Y)));    //"Magic" number xd

            position = pos;
            id = Convert.ToString(random.Next());

            if (id == last)
            {
                throw new Exception($"Id already exist! X = {pos.X}, Y = {pos.Y}");
            }

            last = id;
        }

        public Point(string id, Position pos)
        {
            position = pos;
            this.id = id;
        }

        string IPoint.GetID()
        {
            return id;
        }

        Position IPoint.GetPosition()
        {
            return position;
        }

        void IPoint.SetPosition(Position pos)
        {
            if (pos != null)
                position = pos;
        }
    }
}
