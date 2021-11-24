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
            //return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Product> products;

            if (number == 0)
            {
                products = context.Products.ToList();
            }
            else
            {
                products = (from p in context.Products
                          orderby p.Name descending
                          select p).Take(number).ToList();
            }

            return PartialView("_PhotoGallery", products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }


        [HttpPost]
       
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
           
            if (!ModelState.IsValid)
            {
                return View("Create", product);
            }
            else
            {
                if (image != null)
                {
                    product.ImageMimeType =
                    image.ContentType;
                    product.Picture = new
                    byte[image.ContentLength];
                    image.InputStream.Read(
                    product.Picture, 0,
                    image.ContentLength);
                }
            }

            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
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

        public FileContentResult GetImage(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                return File(product.Picture,
                product.ImageMimeType);
            }
            else
            {
                return null;
            }

        }

    }
}