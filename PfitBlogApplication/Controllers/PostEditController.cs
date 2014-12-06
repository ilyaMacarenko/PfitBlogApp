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
    public class PostEditController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /PostEdit/

        public ActionResult Index()
        {
            return View(db.postSet.ToList());
        }

        //
        // GET: /PostEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            PostModel postmodel = db.postSet.Find(id);
            if (postmodel == null)
            {
                return HttpNotFound();
            }
            return View(postmodel);
        }

        //
        // GET: /PostEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PostEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModel postmodel)
        {
            if (ModelState.IsValid)
            {
                db.postSet.Add(postmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postmodel);
        }

        //
        // GET: /PostEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PostModel postmodel = db.postSet.Find(id);
            if (postmodel == null)
            {
                return HttpNotFound();
            }
            return View(postmodel);
        }

        //
        // POST: /PostEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostModel postmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postmodel);
        }

        //
        // GET: /PostEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PostModel postmodel = db.postSet.Find(id);
            if (postmodel == null)
            {
                return HttpNotFound();
            }
            return View(postmodel);
        }

        //
        // POST: /PostEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostModel postmodel = db.postSet.Find(id);
            db.postSet.Remove(postmodel);
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