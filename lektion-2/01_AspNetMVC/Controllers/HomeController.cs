using _01_AspNetMVC.Data;
using _01_AspNetMVC.Models;
using _01_AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger , IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Products = await _productService.GetAllAsync();
            return View(viewModel);
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
    }
}