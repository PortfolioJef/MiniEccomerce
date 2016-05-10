using FluentNHibernate.Mapping;

namespace SwEcommerce.Models
{
    public class ProdutosMap : ClassMap<Produtos>
    {
        public ProdutosMap()
        {
            Id(p => p.identificador);
            Map(p => p.Nome);
            Map(p => p.Preco);
            Table("Produtos");
        }
    }
}