using PfitBlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PfitBlogApplication.Models
{
    public class LoginController : Controller
    {
        private BlogContext db = new BlogContext();
        private bool isExistEmail = false;
        private bool isExistPassword = false;
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginModel model)
        {
            List<String> email = db.loginSet.Select(t => t.Email).ToList();
            List<String> passwords = db.loginSet.Select(t => t.Password).ToList();
            if(ModelState.IsValid)
            {
                String Email = model.Email;
                String Password = model.Password;
                foreach( String em in email){
                    if (em.Equals(Email)) {
                        isExistEmail = true;
                        break;
                    }
                }
                foreach (String pas in passwords) {
                    if (pas.Equals(Password)) {
                        isExistPassword = true;
                        break;
                    }
                }
                if (isExistEmail && isExistPassword)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("menu", "user");
                }
                else
                {
                    return RedirectToAction("index","Home");
                }
            }
            return View();
        }

    }
}
