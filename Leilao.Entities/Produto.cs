using InfoverdeCore.Entities;
using System;
using System.Collections.Generic;

namespace Leilao.Entities
{
    public enum ProdutoCategoria {
        NaoDefinido=0,
        Imovel = 1,
        Veiculo = 2
    }

    public class Produto : BaseEntity
    {
        public int ProdutoID { get; set; }
        public Leilao Leilao { get; set; }
        public ProdutoCategoria Categoria { get; set; }
        public string Descricao { get; set; }
        public DateTime SiteUrl { get; set; }
        public List<Imagem> Imagens { get; set; }
    }

    
}
