using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PfitBlogApplication.Models
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

    }
}
