using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
