using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Order
    {
        public Order()
        {
            Details = new HashSet<Detail>();
        }

        public int OrderId { get; set; }
        public string? Type { get; set; }
        public string? Userid { get; set; }
        public DateTime? DateOrder { get; set; }
        public double? Total { get; set; }

        public virtual Account? UsernameNavigation { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
