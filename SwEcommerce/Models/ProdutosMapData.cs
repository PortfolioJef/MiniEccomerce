using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;  

namespace SwEcommerce.Models
{
    public class ProdutosMapData : ClassMap<Produtos>
    {
        public ProdutosMapData()
        {
            Table("Produtos");
            Id(id=>id.identificador,"identificador");
            Map(x => x.nome, "nome");
            Map(x => x.preco, "preco");
                    }
    }
}