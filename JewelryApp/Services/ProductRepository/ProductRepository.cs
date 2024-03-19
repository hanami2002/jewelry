using DataTranferObject.ProductDTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductRepository
{
    public class ProductRepository : IProductRepository
    { 
        private readonly JewelryContext _context;

        public ProductRepository(JewelryContext context) {
            _context = context;
        }

        public List<ProductResponeDTO> GetAll(string serach)
        {
            var list= _context.Products.Where(x=>x.Name.ToLower().Equals(serach.ToLower()));
            var result = list.Select(x => new ProductResponeDTO
            {
                ProductId = x.ProductId,
                Name = x.Name,
                InStock = x.InStock
            }).ToList();
            return result;
        }
    }
}
