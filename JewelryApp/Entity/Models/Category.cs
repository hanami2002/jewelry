using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Enable=false;
        }

        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public bool? Enable { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
