using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public int? Category {  get; set; }
        public int? ProductId {  get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Detail(int? ProductId)
        {
            if(ProductId != null)
            {
               
                ViewBag.ProductId = ProductId;
            }
            
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Shop(int? category)
        {
            if (category != null)
            {

                ViewBag.Category = category;
            }
            return View();
        }
        public IActionResult Price()
        {
            return View();
        }
    }
}
