using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ManageOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
