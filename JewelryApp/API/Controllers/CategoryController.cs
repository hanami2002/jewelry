using DataTranferObject.CategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet("Get/{id}")]
        public ActionResult<CategoryResponeDTO> GetById(int id)
        {
            try
            {
                var category = categoryRepository.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving category");
            }
        }
         
        
        [HttpGet("{id}")]
        public ActionResult GetAll(string id)
        {
            try
            {
                var category = categoryRepository.GetAll(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving category");
            }
        }

        [HttpPost]
        public ActionResult Create(CategoryRequestDTO categoryDTO)
        {
            try
            {
                categoryRepository.Create(categoryDTO);
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating category");
            }
        }

        [HttpPut]
        public ActionResult Update(CategoryRequestDTO categoryDTO)
        {
            try
            {
                categoryRepository.Update(categoryDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating category");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                categoryRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting category");
            }
        }
    }
}
