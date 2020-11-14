using System;
using System.Text.Json;
using DurkaDungeon.Core;

namespace DurkaDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            IBootstrap bootstrap = new Bootstrap();

            bootstrap.Init();
        }
    }
}
