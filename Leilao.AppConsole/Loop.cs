using Leilao.Entities;
using Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.AppConsole
{
    class Loop
    {
        public void Start()
        {
            Console.WriteLine("Loop Start - Begin");

            List<Usuario> usuarios = new List<Usuario>();

            for (int i = 0; i < 1000; i++)
            {
                usuarios.Add(new Usuario()
                {
                    Username = $"{i}user-{DateTime.Now.Ticks}",
                    Password = "123456",
                    Observacao = new String('x', 500000)
                });
            }

            usuarios = null;

            Console.WriteLine("Loop Start - End");
        }
    }
}
