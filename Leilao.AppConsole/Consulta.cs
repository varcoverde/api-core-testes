using Leilao.Entities;
using Leilao.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.AppConsole
{
    class Consulta : IDisposable, IAsyncDisposable
    {
        private AppDbContext context;
        public Consulta()
        {
            this.context = new AppDbContext();
        }

        public void Start()
        {
            var leiloeiros = context.Leiloeiros.Take(100).ToList();

            for (int i = 0; i < leiloeiros.Count; i++)
            {
                var leiloes = context.Leiloes
                    .AsNoTracking()
                    .IgnoreAutoIncludes()
                    .Where(x => x.Leiloeiro.LeiloeiroID == leiloeiros[i].LeiloeiroID).Take(100).ToList();

                for (int ix = 0; ix < leiloes.Count; ix++)
                {
                    var imoveis = context.Imoveis.Where(x => x.Leilao.LeilaoID  == leiloes[ix].LeilaoID).Take(100).ToList();


                    for (int imix = 0; imix < imoveis.Count; imix++)
                    {
                        Console.WriteLine(
                            JsonConvert.SerializeObject(
                                imoveis[imix],
                                new JsonSerializerSettings() {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                })); 
                    }
                }
            }
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
