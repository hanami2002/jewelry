using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.DetailDTO
{
    public class DetailResponeDTO
    {
        public int DetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? Total { get; set; }
    }
}
