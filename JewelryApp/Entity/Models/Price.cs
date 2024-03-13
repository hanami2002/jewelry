using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public string? Arena { get; set; }
        public double? SellPrice { get; set; }
        public double? BuyPrice { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? MaterialId { get; set; }

        public virtual Material? Material { get; set; }
    }
}
