using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DominosMVC.Controllers
{
    public class DominosController : Controller
    {

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult MenuPage(string username)
        {
            Session["username"] = username;

            return View();
        }

        public ActionResult Checkout()
        {    

            return View();
        }
        [HttpGet]
        public ActionResult SuccessPage()
        {

            return View();
        }

        public ActionResult OrderHistory()
        {

            return View();
        }

        public ActionResult Logout()
        {
           // FormsAuthentication.SignOut();
            Session["username"] = null;
            return Redirect("/JwtAuthentication/Index");
        }
    }
}