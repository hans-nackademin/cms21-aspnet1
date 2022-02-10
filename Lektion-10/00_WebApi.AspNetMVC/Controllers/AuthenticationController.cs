using _00_WebApi.AspNetMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _00_WebApi.AspNetMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        public IActionResult SignIn()
        {
            ViewData["ErrorMessage"] = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel m)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7145/api/");

                var response = await client.PostAsJsonAsync("authentication/signin", m);

                if(response.IsSuccessStatusCode)
                {
                    _logger.LogInformation(await response.Content.ReadAsStringAsync());
                    
                    HttpContext.Session.SetString("AccessToken", await response.Content.ReadAsStringAsync());
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewData["ErrorMessage"] = await response.Content.ReadAsStringAsync();
                    return View(m);
                }
            }
        }
    }
}
