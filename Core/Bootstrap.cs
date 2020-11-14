using System;
using System.Collections.Generic;
using System.Text;

namespace DurkaDungeon.Core
{
    interface IBootstrap
    {
        Map.IMap GetMap(); 
        void Init();


    }


    class Bootstrap : IBootstrap
    {
        private Map.IMap map;
        private void InitConsole(string title)
        {
            Console.Title = title.Length <= 0 ? "DD" : title;
        }

        void IBootstrap.Init()
        {
            Console.WriteLine("Init");   //Best log system btw

            InitConsole("DurkaDungeon");
            map = new Map.BaseMap();
            map.Generate(20, 10);

            /*Console.BufferWidth = map.GetSize().X;
            Console.BufferHeight = map.GetSize().Y;*/

            Console.WriteLine("Init successfully");
            Console.WriteLine("Wait 3 seconds");

            for (int i = 1; i < 4; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write('.');
            }

            Console.Clear();
        }

        Map.IMap IBootstrap.GetMap()
        {
            return map;
        }
    }
}
