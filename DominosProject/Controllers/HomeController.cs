using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PizzaBAL;
namespace DominosProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

       
        public ActionResult HomePage()
        {
           

            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }



        [Authorize]
        public ActionResult PizzaMenu()
        {
            return View();
        }

 
    }
}
