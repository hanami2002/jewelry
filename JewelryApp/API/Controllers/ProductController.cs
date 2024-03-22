using DataTranferObject.ProductDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
       

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetProduct(string pagenamme,string? search, decimal? from, decimal? to, int? categoryID, int? materialID, int page = 1)
        {
            try
            {
                var result = _productRepository.GetProductPages(pagenamme,search, from, to, categoryID, materialID, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddProduct")]
        public IActionResult addProduct(ProductRequestDTO product)
        {
            try
            {
                _productRepository.addProduct(product);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut("update")]
        public IActionResult UpdateProduct(int id, ProductRequestDTO product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            try
            {
                _productRepository.UpdateProduct(product);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
