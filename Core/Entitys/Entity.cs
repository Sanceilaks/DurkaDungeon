using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core.Entitys
{
    class BaseEntity
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
        public Core.Map.GameMap GameMap { get; set; }

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


        /// <summary>
        /// Move entity
        /// 
        /// 
        ///  <code>
        /// For exemple:
        ///   ****
        ///   *P**
        ///   ****
        /// For move up-right  - new Position(1, 1);
        /// For move left-down - new Position(-1, -1);
        /// </code>
        /// </summary>
        public void Move(Types.Position position)
        {
            if (this.Position.X + position.X > GameMap.GetMap().GetSize().X ||
                this.Position.X + position.X < 0)
                return;
            if (this.Position.Y + position.Y > GameMap.GetMap().GetSize().Y ||
                this.Position.Y + position.Y < 0)
                return;

            this.Position.X += position.X;
            this.Position.Y += position.Y;
        }
    }
}
