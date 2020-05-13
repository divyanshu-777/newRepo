using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using System.Web.Security;

namespace DominosProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(LoginDominos lg, string returnurl)
        {
            if (ModelState.IsValid)
            {
                //var ur = db.Logins.Where(x => x.username == lg.username && x.password == lg.password).FirstOrDefault();
                //if (ur != null)
                //{
                //    FormsAuthentication.SetAuthCookie(lg.username, false);
                //    Session["uname"] = lg.username;
                //    if (returnurl != null)
                //        return Redirect(returnurl);
                //    else
                //    {
                //        return Redirect("/New/Create");
                //    }
                //}
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return Redirect("Logins");
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Signup(Login lg)
        //{

        //    db.Logins.Add(lg);
        //    db.SaveChanges();
        //    return Redirect("Logins");


        //}
    }
}