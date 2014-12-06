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
    public class orgController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /org/

        public ActionResult Index()
        {
            return View(db.OrgSet.ToList());
        }

        //
        // GET: /org/Details/5

        public ActionResult Details(int id = 0)
        {
            Org org = db.OrgSet.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        //
        // GET: /org/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /org/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Org org)
        {
            if (ModelState.IsValid)
            {
                db.OrgSet.Add(org);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(org);
        }

        //
        // GET: /org/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Org org = db.OrgSet.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        //
        // POST: /org/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Org org)
        {
            if (ModelState.IsValid)
            {
                db.Entry(org).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(org);
        }

        //
        // GET: /org/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Org org = db.OrgSet.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        //
        // POST: /org/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Org org = db.OrgSet.Find(id);
            db.OrgSet.Remove(org);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Control()
        {
            return View(db.OrgSet.ToList());
        }
    }
}