using InfoverdeCore.Entities;
using System;
using System.Collections.Generic;

namespace Leilao.Entities
{
    public class Leiloeiro : BaseEntity
    {
        public int LeiloeiroID { get; set; }
        public string Nome { get; set; }
        public string SiteUrl { get; set; }
        public List<Leilao> Leiloes { get; set; }
    }
}
