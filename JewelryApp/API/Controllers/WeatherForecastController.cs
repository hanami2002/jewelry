using DataTranferObject.RoleDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.AccountRepository;
using Services.ProductRepository;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AccountRepository _accountRepository;
        //private readonly IProductRepository _productRepository;
        private readonly JewelryContext jewelryContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AccountRepository accountRepository, JewelryContext jewelryContext /*ProductRepository productRepository*/)
        {
            _logger = logger;
            _accountRepository = accountRepository;
            this.jewelryContext = jewelryContext;
            //_productRepository = productRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(Roles = Role.Customer)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel model)
        {
            var result = await _accountRepository.SignUp(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpGet("GetAll")]
        [Authorize]
        public IActionResult IactionResult(/*(string name*/)
        {
            var list= jewelryContext.Products.ToList();
            return Ok(list);
        }
    }
}
