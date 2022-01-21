using Microsoft.AspNetCore.Mvc;

namespace _00_AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
