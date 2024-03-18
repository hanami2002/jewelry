using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.OrderDTO
{
    public class OrderResponeDTO
    {
        public int OrderId { get; set; }
        public string? Type { get; set; }
        public string? Userid { get; set; }
        public DateTime? DateOrder { get; set; }
        public double? Total { get; set; }
    }
}
