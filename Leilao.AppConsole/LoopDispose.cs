using Leilao.Entities;
using Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.AppConsole
{
    class LoopDispose : IDisposable, IAsyncDisposable
    {
        IDisposable _disposableResource = new MemoryStream();
        IAsyncDisposable _asyncDisposableResource = new MemoryStream();

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
                _disposableResource?.Dispose();
                (_asyncDisposableResource as IDisposable)?.Dispose();
            }

            _disposableResource = null;
            _asyncDisposableResource = null;
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            //if (_asyncDisposableResource is not null)
            if (_asyncDisposableResource != null)
            {
                await _asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
            }

            if (_disposableResource is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                _disposableResource.Dispose();
            }

            _asyncDisposableResource = null;
            _disposableResource = null;
        }
    }
}
