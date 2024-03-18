using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.ProductDTO
{
    public class ProductResponeDTO
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? SellPrice { get; set; }
        public string? CategoryName { get; set; }
        public int? InStock { get; set; }
        public string? Desciption { get; set; }
        public string? Detail { get; set; }
        public string? ImageLink { get; set; }
        public string? MaterialName { get; set; }
    }
}
