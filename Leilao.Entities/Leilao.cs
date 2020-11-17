using InfoverdeCore.Entities;
using System;
using System.Collections.Generic;

namespace Leilao.Entities
{
    public class Leilao : BaseEntity
    {
        public int LeilaoID { get; set; }
        public Leiloeiro Leiloeiro { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
