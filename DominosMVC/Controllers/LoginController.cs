using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using AutoMapper;
using System.Web.Security;
using DominosMVC.Models;
using PizzaBAL;
namespace DominosMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(LoginDominosClass Dominos, string returnurl)
        {
            UserLoginBAL mb = new UserLoginBAL();
            LoginDto ld = new LoginDto();
            var ur = mb.CheckUser(Mapper.Map<LoginDto>(Dominos));
            //  var data = mb.CheckUser(lg);
            if (ModelState.IsValid)
            {

                // var ur = db.Logins.Where(x => x.username == lg.username && x.password == lg.password).FirstOrDefault();
                if (ur != null)
                {
                    FormsAuthentication.SetAuthCookie(Dominos.Username, false);
                    Session["uname"] = Dominos.Username;
                    if (returnurl != null)
                        return Redirect(returnurl);
                    else
                    {
                        return Redirect("/Home/PizzaMenu");
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return Redirect("LoginPage");
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