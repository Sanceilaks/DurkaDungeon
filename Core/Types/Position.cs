using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Types
{
    class Position
    {
        public Position() { }

        public Position(int x, int y)
        {
            X = x; Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return base.Equals(obj);


            var pos = new Position(((Position)obj).X, ((Position)obj).Y);

            if (pos.X == this.X && pos.Y == this.Y)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
