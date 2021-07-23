using IgnacioQuinteros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IgnacioQuinteros.Controllers
{
    public class HomeController : Controller
    {
        private IQuinterosContext context = new IQuinterosContext();

        public ActionResult Index()
        {
            DbSet<Product> products = GetProducts();

            ViewBag.CoverProducts = products.Take(3);
            ViewBag.Categories = GetCategoriesFromProducts(products);
            return View(products);
        }

        public ActionResult Stores()
        {
            ViewBag.Categories = GetCategoriesFromProducts();
            return View(context.Stores);
        }

        public ActionResult Search(string text)
        {
            DbSet<Product> products = GetProducts();
            if (String.IsNullOrWhiteSpace(text))
            {

            }
            ViewBag.Categories = GetCategoriesFromProducts(products);
            return View();
        }

        public ActionResult Article(int? id)
        {
            DbSet<Product> products = GetProducts();
            ViewBag.Categories = GetCategoriesFromProducts(products);
            return View();
        }

        private DbSet<Product> GetProducts() => context.Products;

        private List<string> GetCategoriesFromProducts()
        {
            DbSet<Product> products = context.Products;

            SortedSet<string> categories = new SortedSet<string>();

            foreach (Product product in products)
            {
                if (product.Category.Length <= 0)
                {
                    continue;
                }
                else if (product.Category.Length == 1)
                {
                    categories.Add(product.Category.ToUpper());
                }
                else if (product.Category.Length > 1)
                {
                    categories.Add(char.ToUpper(product.Category[0]) + product.Category.Substring(1).ToLower());
                }
            }

            return categories.ToList();
        }

        private List<string> GetCategoriesFromProducts(DbSet<Product> products)
        {
            SortedSet<string> categories = new SortedSet<string>();

            foreach (Product product in products)
            {
                if (product.Category.Length <= 0)
                {
                    continue;
                }
                else if (product.Category.Length == 1)
                {
                    categories.Add(product.Category.ToUpper());
                }
                else if (product.Category.Length > 1)
                {
                    categories.Add(char.ToUpper(product.Category[0]) + product.Category.Substring(1).ToLower());
                }
            }

            return categories.ToList();
        }
    }
}