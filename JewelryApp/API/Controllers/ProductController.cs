using DataTranferObject.Paging;
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
                var paging= new PagingRequest<ProductResponeDTO>();
                paging.Items = result;
                paging.PageIndex =page;
                paging.PageSize = 9;
                paging.TotalPage = _productRepository.GetProductPagesNew(pagenamme, search, from, to, categoryID, materialID).Count()/ paging.PageSize+1;
                return Ok(paging);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Admin")]
        public IActionResult GetProductNew(string pagenamme, string? search, decimal? from, decimal? to, int? categoryID, int? materialID, int page = 1)
        {
            try
            {
                var result = _productRepository.GetProductPages(pagenamme, search, from, to, categoryID, materialID, page);
                var paging = new PagingRequest<ProductResponeDTO>();
                paging.Items = result;
                paging.PageIndex = page;
                paging.PageSize = 9;
                var totalElements = _productRepository.GetProductPagesNew(pagenamme, search, from, to, categoryID, materialID).Count();
                paging.TotalPage = totalElements % paging.PageSize == 0 ? totalElements / paging.PageSize : totalElements / paging.PageSize + 1;
                return Ok(paging);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result=_productRepository
                .GetByid(id);
            return Ok(result);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(_productRepository.getProductById(id));
            }
            catch
            {
                return NotFound();
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
