using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.OrderDTO
{
    public class OrderRequestDTO
    {
        public int OrderId { get; set; }
        public string? Type { get; set; }
      
        public string? Name { get; set; }
        public DateTime? DateOrder { get; set; }
        public double? Total { get; set; }
       
    }
}
