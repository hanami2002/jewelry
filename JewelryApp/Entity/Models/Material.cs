using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Material
    {
        public Material()
        {
            Prices = new HashSet<Price>();
            Products = new HashSet<Product>();
        }

        public int MaterialId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
