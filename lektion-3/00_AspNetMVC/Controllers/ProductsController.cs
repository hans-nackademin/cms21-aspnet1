using _00_AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace _00_AspNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }

        public async Task<IActionResult> Laptop()
        {
            return View(await _productService.GetAllBySubCategoryAsync("Bärbara datorer"));
        }

        public async Task<IActionResult> Computer()
        {
            return View(await _productService.GetAllBySubCategoryAsync("Stationära datorer"));
        }

        public IActionResult Tablet()
        {
            return View();
        }

        public IActionResult Network()
        {
            return View();
        }
    }
}
