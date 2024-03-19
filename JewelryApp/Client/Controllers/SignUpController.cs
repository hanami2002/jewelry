using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
