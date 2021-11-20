using PineappleSupermarket.Data;
using PineappleSupermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PineappleSupermarket.Controllers
{
    public class ProductController : Controller
    {
        private ProductDbContext context = new ProductDbContext();
        // GET: Product

        public ActionResult Index()
        {
            
            var products = context.Products.ToList();
            return View("Index", products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }


        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", product);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Detail", product);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Delete", product);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Find(id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult BuscarPorNombre(string nombre)
        {
            if (nombre == "" || nombre == "TODOS")
            {
                return RedirectToAction("Index");
            }

            List<Product> products = (from p in context.Products
                                         where p.Name == nombre
                                         select p).ToList();

            return View("Index", products);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Edit", product);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Product product)

        {

            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", product);

        }

    }
}