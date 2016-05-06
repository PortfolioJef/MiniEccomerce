using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwEcommerce.Models
{
    public class Produtos
    {
        public virtual Guid identificador { get; set; }
        public virtual string nome { get; set; }
        public virtual float preco { get; set; }
        public virtual int? PromoAtrelada { get; set; }
        public Produtos()
        {

        }
    }
}