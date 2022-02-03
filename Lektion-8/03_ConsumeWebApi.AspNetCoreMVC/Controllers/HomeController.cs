using _03_ConsumeWebApi.AspNetCoreMVC.Models;
using _03_ConsumeWebApi.AspNetCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ConsumeWebApi.AspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.Products = new List<ProductModel>();
            viewModel.ProductForm = new ProductModel();
            
            using (var client = new HttpClient())
            {
                viewModel.Products = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7189/api/products?key=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel model)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsJsonAsync("https://localhost:7189/api/products?key=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9", model.ProductForm);
            }

            return RedirectToAction("Index", "Home");
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