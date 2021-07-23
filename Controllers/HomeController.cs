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
            return View(GetStores());
        }

        public ActionResult Search(string text, int? category)
        {
            DbSet<Product> products = GetProducts();
            List<Product> result;
            if (!String.IsNullOrWhiteSpace(text))
            {
                result = new List<Product>();
                foreach (Product product in products)
                {
                    if (category != null && category == 1 && product.Category.ToLower().Equals(text.ToLower()))
                    {
                        result.Add(product);
                        continue;
                    }

                    if (product.Category.ToLower().Contains(text.ToLower()) || 
                        product.Title.ToLower().Contains(text.ToLower())
                    )
                    {
                        result.Add(product);
                        continue;
                    }
                }
            } else
            {
                result = products.ToList();
            }

            ViewBag.SearchText = text;
            ViewBag.Categories = GetCategoriesFromProducts(products);
            return View(result);
        }

        public ActionResult Article(int? id)
        {
            DbSet<Product> products = GetProducts();
            ViewBag.Categories = GetCategoriesFromProducts(products);

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Product product = products.Find(id);

            if(product == null)
            {
                return RedirectToAction("Index");
            }

            List<Product> recommendedProducts = GetProductsFromCategory(products, product.Category);
            recommendedProducts.RemoveAll(delegate(Product refProduct)
            {
                return refProduct.Id == product.Id;
            });

            ViewBag.RecommendedProducts = recommendedProducts;

            return View(product);
        }

        private DbSet<Product> GetProducts() => context.Products;
        private DbSet<Store> GetStores() => context.Stores;

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

        private List<Product> GetProductsFromCategory(DbSet<Product> products, params string[] categories)
        {
            return GetProductsFromCategory(products, categories.ToList());
        }

        private List<Product> GetProductsFromCategory(DbSet<Product> products, List<string> categories)
        {
            List<Product> result = new List<Product>();
            foreach(Product item in products)
            {
                if (categories.Exists(delegate(string category) { 
                    return category.ToLower().Equals(item.Category.ToLower()); 
                }))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}