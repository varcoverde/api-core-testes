using InfoverdeCore.Entities;
using System;

namespace Leilao.Entities
{
    public class Usuario : BaseEntity
    {
        public int UsuarioID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Observacao { get; set; }
    }
}
