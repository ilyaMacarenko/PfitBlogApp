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
    public class UserEditController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /UserEdit/

        public ActionResult Index()
        {
            return View(db.loginSet.ToList());
        }

        //
        // GET: /UserEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            LoginModel loginmodel = db.loginSet.Find(id);
            if (loginmodel == null)
            {
                return HttpNotFound();
            }
            return View(loginmodel);
        }

        //
        // GET: /UserEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginModel loginmodel)
        {
            if (ModelState.IsValid)
            {
                db.loginSet.Add(loginmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginmodel);
        }

        //
        // GET: /UserEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoginModel loginmodel = db.loginSet.Find(id);
            if (loginmodel == null)
            {
                return HttpNotFound();
            }
            return View(loginmodel);
        }

        //
        // POST: /UserEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoginModel loginmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginmodel);
        }

        //
        // GET: /UserEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoginModel loginmodel = db.loginSet.Find(id);
            if (loginmodel == null)
            {
                return HttpNotFound();
            }
            return View(loginmodel);
        }

        //
        // POST: /UserEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginModel loginmodel = db.loginSet.Find(id);
            db.loginSet.Remove(loginmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}