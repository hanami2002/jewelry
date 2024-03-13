using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Detail
    {
        public int DetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? ProductId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
