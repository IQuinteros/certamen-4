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
            return View(context.products);
        }

        public ActionResult Stores()
        {
            return View(context.stores);
        }

        public ActionResult Search(string text)
        {
            DbSet<Product> products = context.products;
            if (String.IsNullOrWhiteSpace(text))
            {

            }
            return View();
        }

        public ActionResult Article(int? id)
        {
            return View();
        }
    }
}