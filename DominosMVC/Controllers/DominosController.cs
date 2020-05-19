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
        [Authorize]
        public ActionResult MenuPage()
        {
            

            return View();
        }

        public ActionResult Checkout()
        {    

            return View();
        }

        public ActionResult SuccessPage()
        {

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return Redirect("/Login/LoginPage");
        }
    }
}