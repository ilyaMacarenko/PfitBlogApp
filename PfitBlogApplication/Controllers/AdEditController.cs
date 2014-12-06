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
    public class AdEditController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /AdEdit/

        public ActionResult Index()
        {
            return View(db.adSet.ToList());
        }

        //
        // GET: /AdEdit/Details/5

        public ActionResult Details(int id = 0)
        {
            AdvertisementModel advertisementmodel = db.adSet.Find(id);
            if (advertisementmodel == null)
            {
                return HttpNotFound();
            }
            return View(advertisementmodel);
        }

        //
        // GET: /AdEdit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdEdit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertisementModel advertisementmodel)
        {
            if (ModelState.IsValid)
            {
                db.adSet.Add(advertisementmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertisementmodel);
        }

        //
        // GET: /AdEdit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AdvertisementModel advertisementmodel = db.adSet.Find(id);
            if (advertisementmodel == null)
            {
                return HttpNotFound();
            }
            return View(advertisementmodel);
        }

        //
        // POST: /AdEdit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvertisementModel advertisementmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisementmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertisementmodel);
        }

        //
        // GET: /AdEdit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AdvertisementModel advertisementmodel = db.adSet.Find(id);
            if (advertisementmodel == null)
            {
                return HttpNotFound();
            }
            return View(advertisementmodel);
        }

        //
        // POST: /AdEdit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvertisementModel advertisementmodel = db.adSet.Find(id);
            db.adSet.Remove(advertisementmodel);
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