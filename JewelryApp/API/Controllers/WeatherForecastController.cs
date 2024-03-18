using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;

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
        private readonly JewelryContext jewelryContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AccountRepository accountRepository, JewelryContext jewelryContext)
        {
            _logger = logger;
            _accountRepository = accountRepository;
            this.jewelryContext = jewelryContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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
        public IActionResult IactionResult()
        {
            var list= jewelryContext.Products.ToList();
            return Ok(list);
        }
    }
}
