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
        void DeleteProduct(int id);
        void UpdateProduct(ProductRequestDTO product);
        void addProduct(ProductRequestDTO product);
    }
}
