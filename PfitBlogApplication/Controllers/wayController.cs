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
    public class wayController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /way/

        public ActionResult Index()
        {
            return View(db.WaySet.ToList());
        }

        //
        // GET: /way/Details/5

        public ActionResult Details(int id = 0)
        {
            Way way = db.WaySet.Find(id);
            if (way == null)
            {
                return HttpNotFound();
            }
            return View(way);
        }

        //
        // GET: /way/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /way/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Way way)
        {
            if (ModelState.IsValid)
            {
                db.WaySet.Add(way);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(way);
        }

        //
        // GET: /way/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Way way = db.WaySet.Find(id);
            if (way == null)
            {
                return HttpNotFound();
            }
            return View(way);
        }

        //
        // POST: /way/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Way way)
        {
            if (ModelState.IsValid)
            {
                db.Entry(way).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(way);
        }

        //
        // GET: /way/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Way way = db.WaySet.Find(id);
            if (way == null)
            {
                return HttpNotFound();
            }
            return View(way);
        }

        //
        // POST: /way/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Way way = db.WaySet.Find(id);
            db.WaySet.Remove(way);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Control()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Control(Way way)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int? direction, int? interval)
        {
            switch(direction)
            {
                case 0:
                case 1:
                    var sortedInfo = db.WaySet.Find(interval);
                    ViewBag.Destination = sortedInfo.Destination;
                    ViewBag.Cost = sortedInfo.Cost;
                    return View(db.WaySet.ToList());
                   
                default:
                    break;
            }
            return View(db.WaySet.ToList());
        }

        [HttpGet]
        public ActionResult Order()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Order(Order order, int? countplaces, int? start, int? end)
        {
            string uzda = "Узда";
            string minsk = "Минск";
            Order mainOrder = new Order();
            mainOrder.CountPlaces = (int)countplaces;
            if (start == 1)
            {
                mainOrder.Start = uzda;
            }
            else
            {
                mainOrder.Start = minsk;
            }
            switch ((int)end)
            {
                case 1:
                    mainOrder.End = "Каменка";
                    break;
                case 2:
                    mainOrder.End = "Литвяны";
                    break;
                case 3:
                    mainOrder.End = "Логовоище";
                    break;
                case 4:
                    mainOrder.End = "Городище";
                    break;
                case 5:
                    mainOrder.End = "Каменка";
                    break;
                case 6:
                    mainOrder.End = "Энергетик";
                    break;
                case 7:
                    mainOrder.End = "Негорелое";
                    break;
                case 8:
                    mainOrder.End = "Дзержинск";
                    break;
                case 9:
                    mainOrder.End = "Фаниполь";
                    break;
                case 10:
                    mainOrder.End = "Пятигорье";
                    break;
                case 11:
                    mainOrder.End = "Столичный";
                    break;
                case 12:
                    mainOrder.End = "Станьково";
                    break;
                case 13:
                    mainOrder.End = "Клыповщина";
                    break;

            }
            mainOrder.TimeStart = order.TimeStart;
            mainOrder.Phone = order.Phone;
            if (ModelState.IsValid) 
            {
                db.OrderSet.Add(mainOrder);
                db.SaveChanges();
                return RedirectToAction("index", "time");
            }
            

            
            
            return RedirectToAction("order","way");
        }
    }
}