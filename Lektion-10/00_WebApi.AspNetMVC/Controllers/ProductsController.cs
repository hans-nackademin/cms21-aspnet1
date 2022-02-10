using _00_WebApi.AspNetMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace _00_WebApi.AspNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> products = new List<ProductViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7145/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("AccessToken"));

                products = await client.GetFromJsonAsync<IEnumerable<ProductViewModel>>("products");

            }

            return View(products);
        }
    }
}
