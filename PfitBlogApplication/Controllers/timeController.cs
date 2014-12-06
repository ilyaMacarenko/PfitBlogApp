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
    public class timeController : Controller
    {
        private BlogContext db = new BlogContext();
        private String[] mDays = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
        private String[] mDirection = { "Узда-Минск", "Минск-Узда"};
        //
        // GET: /time/

        public ActionResult Index()
        {
            return View(db.TimeSet.ToList());
        }

        //
        // GET: /time/Details/5

        public ActionResult Details(int id = 0)
        {
            Time time = db.TimeSet.Find(id);
            
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        //
        // GET: /time/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /time/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Time time)
        {
            if (ModelState.IsValid)
            {
                db.TimeSet.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(time);
        }

        //
        // GET: /time/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Time time = db.TimeSet.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        //
        // POST: /time/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(time);
        }

        //
        // GET: /time/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Time time = db.TimeSet.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        //
        // POST: /time/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.TimeSet.Find(id);
            db.TimeSet.Remove(time);
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
            return View(db.TimeSet.ToList());
        }
        [HttpPost]
        public ActionResult Index(int? count, int? days, int? direction)
        {
           
            ViewBag.Cost = 25000 * count;
            if(days != null && direction != null)
            {
                String day = mDays[(int)days];
                String direct = mDirection[(int)direction];
                var finalInfo = db.TimeSet.Where(t => t.Direction == direct && t.Day == day).ToList();
                return View(finalInfo);
            } else {
                return View(db.TimeSet.ToList());        
            }
            
        }


    }
}