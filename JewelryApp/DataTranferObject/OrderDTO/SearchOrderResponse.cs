using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.OrderDTO
{
    public class SearchOrderResponse
    {
        public List<OrderResponse> Orders { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }

    public class OrderResponse : OrderResponeDTO
    {
        public bool? Status { get; set; }
    }
}
