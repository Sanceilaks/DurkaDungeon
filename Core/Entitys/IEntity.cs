using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Entitys
{
    interface IEntity
    {
        public char DrawChar { get; }

        public string Id { get; }

    }



    class BaseEntity : IEntity
    {
        static protected int entNum = 0;


        public virtual char DrawChar { get; }
        private readonly Random random = new Random(1488 * 1488 + Environment.TickCount + 
            (Environment.ProcessorCount - (Environment.OSVersion.Version.Build * 2 - Environment.TickCount)) + 
            entNum * Environment.TickCount);
        public bool IsVisible { get; set; }  = false;
        public bool IsTakePart { get; set; } = false;
        public Core.Types.Position Position { get; set; }

        public string Id { get; }

        public BaseEntity()
        {
            Id = random.Next().ToString();
            entNum++;
        }

        public BaseEntity(string id)
        {
            Id = id;
            entNum++;
        }

        public BaseEntity(string id, Core.Types.Position position)
        {
            Id = id;
            Position = position;
            entNum++;
        }
        public BaseEntity(Core.Types.Position position)
        {
            Position = position;
            Id = random.Next().ToString();
            entNum++;
        }
    }
}
