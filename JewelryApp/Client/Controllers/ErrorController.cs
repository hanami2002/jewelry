using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
