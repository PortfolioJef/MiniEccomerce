namespace SwEcommerce.Models
{
    public class Produtos
    {
        public virtual int identificador { get; set; }
        public virtual string Nome { get; set; }
        public virtual float Preco { get; set; }
        public virtual int PromoId { get; set; }
    }
}