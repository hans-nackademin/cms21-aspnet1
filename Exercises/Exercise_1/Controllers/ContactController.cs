using Microsoft.AspNetCore.Mvc;

namespace Exercise_1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
