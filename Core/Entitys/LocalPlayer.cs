using System;
using System.Collections.Generic;
using System.Text;
using DurkaDungeon.Core.Types;

namespace DurkaDungeon.Core.Entitys
{
    class LocalPlayer : BaseEntity
    {
        override public char DrawChar { get; } = 'P';

        public LocalPlayer() : base() { }

        public LocalPlayer(Position position) : base(position)
        {
        }

        public LocalPlayer(string id, Position position) : base(id, position)
        {
        }

    }
}
