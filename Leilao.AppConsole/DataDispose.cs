using Leilao.Entities;
using Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.AppConsole
{
    class DataDispose : IDisposable, IAsyncDisposable
    {
        private AppDbContext context;
        public DataDispose() {
            this.context = new AppDbContext();
        }

        public void Start()
        {
            context.Database.EnsureCreated();

            for (int i = 0; i < 100; i++)
            {
                context.Add(new Usuario()
                {
                    Username = $"{i}user-{DateTime.Now.Ticks}",
                    Password = "123456"
                });
            }

            for (int i = 0; i < 10; i++)
            {
                context.Add(new Leiloeiro()
                {
                    Nome = $"{i}leiloeiro-{DateTime.Now.Ticks}",
                    SiteUrl = "http://"
                });
            }

            context.SaveChanges();

            var leiloeiros = context.Leiloeiros.ToList();

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

                    context.Add(leilao);

                    leilao = null;
                }
            }

            context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                context.Add(new Leiloeiro()
                {
                    Nome = $"{i}leiloeiro-{DateTime.Now.Ticks}",
                    SiteUrl = "http://"
                });
            }

            var usuarios = context.Usuarios.ToList();

            //usuarios.ForEach(u => {
            //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(u));
            //});

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context?.Dispose();
            }

            context = null;
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (context is IAsyncDisposable disposable)
                await disposable.DisposeAsync().ConfigureAwait(false);
            else
                context.Dispose();
            context = null;
        }
    }
}
