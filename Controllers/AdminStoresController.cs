using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IgnacioQuinteros.Models;

namespace IgnacioQuinteros.Controllers
{
    public class AdminStoresController : Controller
    {
        private IQuinterosContext context = new IQuinterosContext();

        public ActionResult Index()
        {
            return View(context.Stores.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return RedirectToAction("Index");
            }
            return View(store);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ImageUrl,Address")] Store store)
        {
            if (ModelState.IsValid)
            {
                context.Stores.Add(store);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return RedirectToAction("Index");
            }
            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ImageUrl,Address")] Store store)
        {
            if (ModelState.IsValid)
            {
                context.Entry(store).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return RedirectToAction("Index");
            }
            return View(store);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = context.Stores.Find(id);
            context.Stores.Remove(store);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
