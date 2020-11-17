using InfoverdeCore.Entities;
using System;
using System.Collections.Generic;

namespace Leilao.Entities
{
    public class Imovel : Produto
    {
        public string ImovelTipo { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public decimal Metragem { get; set; }
    }
}
