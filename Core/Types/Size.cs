using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Types
{
    class Size
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Size() { }

        public Size(int x, int y)
        {
            X = x; Y = y;
        }

        public int GetSquare()
        {
            return X * Y;
        }
    }
}
