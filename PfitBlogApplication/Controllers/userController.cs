using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PfitBlogApplication.Models;

namespace PfitBlogApplication.Controllers
{
    public class userController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /user/

        public ActionResult Index()
        {
            return View(db.UserSet.ToList());
        }

        //
        // GET: /user/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /user/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /user/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        
        {
            int count = db.UserSet.ToList().Count;
            if (ModelState.IsValid)
            {
                user.UserId = count + 1;
                db.UserSet.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /user/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /user/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /user/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /user/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.UserSet.Find(id);
            db.UserSet.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult AllOrders()
        {
            return View(db.OrderSet.ToList());
        }
    }
}