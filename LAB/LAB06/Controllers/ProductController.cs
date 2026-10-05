using LAB06.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LAB06.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 50000,
                    Brand = "Dell",
                    Description = "A powerful laptop for students and office work.",
                    Color = "Black",
                    Stock = 10
                },

                new Product
                {
                    Id = 2,
                    Name = "Mobile Phone",
                    Category = "Electronics",
                    Price = 20000,
                    Brand = "Samsung",
                    Description = "A modern smartphone with a good camera.",
                    Color = "Blue",
                    Stock = 15
                },

                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Category = "Accessories",
                    Price = 2000,
                    Brand = "Sony",
                    Description = "Wireless headphones with good sound quality.",
                    Color = "Black",
                    Stock = 20
                },

                new Product
                {
                    Id = 4,
                    Name = "Smart Watch",
                    Category = "Accessories",
                    Price = 5000,
                    Brand = "Boat",
                    Description = "Smart watch with fitness and health tracking features.",
                    Color = "Black",
                    Stock = 12
                },

                new Product
                {
                    Id = 5,
                    Name = "Keyboard",
                    Category = "Computer Accessories",
                    Price = 1500,
                    Brand = "Logitech",
                    Description = "Comfortable keyboard for daily computer use.",
                    Color = "White",
                    Stock = 25
                }
            };

            return View(products);
        }

        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 50000,
                    Brand = "Dell",
                    Description = "A powerful laptop for students and office work.",
                    Color = "Black",
                    Stock = 10
                },

                new Product
                {
                    Id = 2,
                    Name = "Mobile Phone",
                    Category = "Electronics",
                    Price = 20000,
                    Brand = "Samsung",
                    Description = "A modern smartphone with a good camera.",
                    Color = "Blue",
                    Stock = 15
                },

                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Category = "Accessories",
                    Price = 2000,
                    Brand = "Sony",
                    Description = "Wireless headphones with good sound quality.",
                    Color = "Black",
                    Stock = 20
                },

                new Product
                {
                    Id = 4,
                    Name = "Smart Watch",
                    Category = "Accessories",
                    Price = 5000,
                    Brand = "Boat",
                    Description = "Smart watch with fitness and health tracking features.",
                    Color = "Black",
                    Stock = 12
                },

                new Product
                {
                    Id = 5,
                    Name = "Keyboard",
                    Category = "Computer Accessories",
                    Price = 1500,
                    Brand = "Logitech",
                    Description = "Comfortable keyboard for daily computer use.",
                    Color = "White",
                    Stock = 25
                }
            };

            Product product = products.Find(p => p.Id == id);

            return View(product);
        }
    }
}