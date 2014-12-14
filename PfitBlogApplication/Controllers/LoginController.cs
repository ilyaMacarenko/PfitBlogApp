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
            List<User> email = db.UserSet.ToList();
         
            if(ModelState.IsValid)
            {
                String Email = model.Email;
                String Password = model.Password;
                foreach( User em in email){
                    if (em.Email.ToString().Trim().Equals(Email) 
                        && em.Password.ToString().Trim().Equals(Password)){
                        isExistEmail = true;
                        break;
                    }
                }
                if (isExistEmail)
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
