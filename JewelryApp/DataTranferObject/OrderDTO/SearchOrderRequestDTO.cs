using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.OrderDTO
{
    public class SearchOrderRequestDTO
    {
        public string? Type { get; set; }
        public bool? Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? PageIndex { get; set; }
    }
}
