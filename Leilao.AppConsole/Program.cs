using Leilao.Entities;
using Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < 5; i++)
            {
                using (var loop = new Consulta())
                {
                    loop.Start();
                }
            }
            Console.ReadKey();

            for (int i = 0; i < 20; i++)
            {
                var loop = new Loop();
                loop.Start();
            }
            Console.ReadKey();
            for (int i = 0; i < 5; i++)
            {
                using (var loop = new LoopDispose())
                {
                    loop.Start();
                }
            }
            Console.ReadKey();
            for (int i = 0; i < 5; i++)
            {
                using (var loop = new DataDispose())
                {
                    loop.Start();
                }
            }
            Console.ReadKey();
            for (int i = 0; i < 5; i++)
            {
                var loop = new Data();
                loop.Start();
            }
            Console.ReadKey();
        }
    }
}
