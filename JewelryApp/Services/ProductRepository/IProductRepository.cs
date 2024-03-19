using DataTranferObject.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductRepository
{
    public interface IProductRepository
    {
        List<ProductResponeDTO> GetAll(string serach);
    }
}
