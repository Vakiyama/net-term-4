using Microsoft.AspNetCore.Mvc;
using class_2.Models;

namespace MyMvcApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m },
                new Product { Id = 2, Name = "Smartphone", Price = 599.99m },
                new Product { Id = 3, Name = "Tablet", Price = 299.99m }
            };

            // Store the products in ViewData
            ViewData["Products"] = products;

            return View();
        }

        [HttpGet("json")]
        public IActionResult GetProductsJson()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m },
                new Product { Id = 2, Name = "Smartphone", Price = 599.99m },
                new Product { Id = 3, Name = "Tablet", Price = 299.99m }
            };

            return Ok(products);
        }
    }
}

