using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MFCS.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user,string returnUrl)
        {
            var admin = context.Users.FirstOrDefault(x => x.Type == "Admin" && x.Status ==1);
            var data = context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (data != null && admin!=null)
            {
                //if(admin!=null) {
                Session["id"] = admin.Id;
                FormsAuthentication.SetAuthCookie(data.Email, true);
             
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect("User");
                   // }
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }
            // var use = context.Users.FirstOrDefault(e => e.Id == user.Id);
            // context.Entry(use).CurrentValues.SetValues(user);
            //context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }
    }
}