using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            Details = new HashSet<Detail>();
        }

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? SellPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? InStock { get; set; }
        public string? Desciption { get; set; }
        public string? Detail { get; set; }
        public string? ImageLink { get; set; }
        public int? MaterialId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Material? Material { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
