using PfitBlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PfitBlogApplication.Controllers
{
    public class PopularController : Controller
    {
        //
        // GET: /Popular/
        private BlogContext _db = new BlogContext();

        public ActionResult Index()
        {
            var allPost = _db.postSet.ToList<PostModel>();
            return View(allPost);
        }

        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(Models.PostModel post)
        {
            if (ModelState.IsValid)
            {
                PostModel pm = new PostModel();
                pm.Title = post.Title;
                pm.AuthorName = post.AuthorName;
                pm.Content = post.Content;
                pm.Time = DateTime.Now;

                _db.postSet.Add(pm);
                _db.SaveChanges();
                return RedirectToAction("index", "popular");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Comment()
        {
            return View();
        }

//        [HttpPost]
//        public ActionResult Comment()
//        {
//            return View();
//        }
    }


}
