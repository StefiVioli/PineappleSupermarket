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
    public class UserController : Controller
    {
        
        private UserDbContext context = new UserDbContext();
      
        public ActionResult Index()
        {

            //List<User> users = (from u in context.Users
            //                          select u.Username && u.CreatedDate).ToList();
            var users = context.Users.ToList();
            return View("Index", users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            User user = new User();
            return View("Create", user);
        }


        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = context.Users.Find(id);

            if (user != null)
            {
                return View("Delete", user);
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
            User user = context.Users.Find(id);

            context.Users.Remove(user);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

   
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = context.Users.Find(id);

            if (user != null)
            {
                return View("Edit", user);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(User user)

        {

            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", user);

        }

    }
}