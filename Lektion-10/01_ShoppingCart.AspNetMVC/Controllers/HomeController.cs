using _01_ShoppingCart.AspNetMVC.Helpers;
using _01_ShoppingCart.AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_ShoppingCart.AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        List<ProductModel> _productList = new List<ProductModel>()
        {
            new ProductModel() { Id = 1, Name = "Product 1", Price = 100 },
            new ProductModel() { Id = 2, Name = "Product 2", Price = 200 },
            new ProductModel() { Id = 3, Name = "Product 3", Price = 300 },
            new ProductModel() { Id = 4, Name = "Product 4", Price = 400 }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }





        public IActionResult Index()
        {
            ViewBag.Products = _productList;
            ViewBag.ShoppingCart = SessionHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "shoppingCart");
            return View();
        }


        public IActionResult AddToCart(int id)
        {
            if(SessionHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "shoppingCart") == null)
            {
                List<CartItem> shoppingCart = new List<CartItem>();
                shoppingCart.Add(new CartItem() { Product = _productList.Find(x => x.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
            }
            else
            {
                List<CartItem> shoppingCart = SessionHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "shoppingCart");
                int index = ItemExists(id);
                if (index != -1)
                    shoppingCart[index].Quantity++;
                else
                    shoppingCart.Add(new CartItem() { Product = _productList.Find(x => x.Id == id), Quantity = 1 });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
            }
            
            return RedirectToAction("Index");
        }



        public int ItemExists(int id)
        {
            List<CartItem> shoppingCart = SessionHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "shoppingCart");
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                if (shoppingCart[i].Product.Id == id)
                    return i;
            }

            return -1;
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