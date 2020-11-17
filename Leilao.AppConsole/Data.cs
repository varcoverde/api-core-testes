using Leilao.Entities;
using Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.AppConsole
{
    class Data
    {
        public void Start()
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Database.EnsureCreated();

                for (int i = 0; i < 100; i++)
                {
                    ctx.Add(new Usuario()
                    {
                        Username = $"{i}user-{DateTime.Now.Ticks}",
                        Password = "123456"
                    });
                }

                for (int i = 0; i < 10; i++)
                {
                    ctx.Add(new Leiloeiro()
                    {
                        Nome = $"{i}leiloeiro-{DateTime.Now.Ticks}",
                        SiteUrl = "http://"
                    });
                }

                ctx.SaveChanges();

                var leiloeiros = ctx.Leiloeiros.ToList();

                foreach (var leiloeiro in leiloeiros)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var leilao = new Leilao.Entities.Leilao()
                        {
                            Leiloeiro = leiloeiro,
                            Produtos = new List<Produto>()
                        };

                        for (int i2 = 0; i2 < 10; i2++)
                        {
                            var produto = new Imovel()
                            {
                                Imagens = new List<Imagem>(),
                                Leilao = leilao,
                                Descricao = "asd asda sdas das dasd asd asd asdas dsa",
                                Estado = "RJ",
                                Municipio = "Rio de Janeiro",
                                Bairro = "Barra da Tijuca",
                                Logradouro = "asdadasdasd",
                                Numero = "3500",
                                Complemento = "Bloco 1 Sala 305",
                                CEP = "20050-200"
                            };

                            for (int i3 = 0; i3 < 5; i3++)
                            {
                                var imagem = new Imagem()
                                {
                                    OrigiemUrl = "http://",
                                };

                                produto.Imagens.Add(imagem);
                            }

                            leilao.Produtos.Add(produto);
                        }

                        ctx.Add(leilao);

                        leilao = null;
                    }
                }

                ctx.SaveChanges();

                for (int i = 0; i < 100; i++)
                {
                    ctx.Add(new Leiloeiro()
                    {
                        Nome = $"{i}leiloeiro-{DateTime.Now.Ticks}",
                        SiteUrl = "http://"
                    });
                }

                var usuarios = ctx.Usuarios.ToList();

                //usuarios.ForEach(u => {
                //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(u));
                //});

                ctx.Dispose();
            }
        }
    }
}
