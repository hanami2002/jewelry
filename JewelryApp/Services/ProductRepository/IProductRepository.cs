using DataTranferObject.ProductDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductRepository
{
    public interface IProductRepository
    {
        List<ProductResponeDTO> GetProductPages(string pagename,string? search, decimal? from, decimal? to, int? categoryID, int? materialID, int page = 1);

        //ProductVM AddProduct(Product product);
       public void DeleteProduct(int id);
        public void UpdateProduct(ProductRequestDTO product);
        public void addProduct(ProductRequestDTO product);
        public  ProductResponeDTO GetByid(int id);
        ProductResponeDTO getProductById(int id);
        public List<ProductResponeDTO> GetProductPagesNew(string pagename, string? search, decimal? from, decimal? to, int? categoryID, int? materialID);
    }
}
