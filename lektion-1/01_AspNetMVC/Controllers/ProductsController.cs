using _01_AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _01_AspNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var product = new ProductModel() { Id = 1, Name = "Product 1", Description = "En beskrivning", Price = 100 };
            var products = new List<ProductModel>();
            products.Add(product);
            
            return View(products);
        }

        public IActionResult Details()
        {
            var product = new ProductModel() { Id = 1, Name = "Product 1", Description = "En beskrivning", Price = 100 };

            return View(product);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
