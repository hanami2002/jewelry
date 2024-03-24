using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ManageProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
