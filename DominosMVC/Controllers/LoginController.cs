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
using System.Net.Http;

namespace DominosMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        /// <summary>
        /// This method will authenticate user.
        /// </summary>
        /// <param name="Dominos"></param>
        /// <param name="returnurl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginPage(LoginDominosClass Dominos, string returnurl)
        {
            UserLoginBAL mb = new UserLoginBAL();
            LoginDto ld = new LoginDto();
            var ur = mb.CheckUser(Mapper.Map<LoginDto>(Dominos));
            if (ModelState.IsValid)
            {
                if (ur != null)
                {
                    FormsAuthentication.SetAuthCookie(Dominos.Username, false);
                    Response.Cookies["Username"].Value= Dominos.Username;
                    if (returnurl != null)
                        return Redirect(returnurl);
                    else
                    {
                        return Redirect("/Dominos/MenuPage");
                    }
                }
                else
                {
                    ViewBag.Data = "Username or Password is incorrect!";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDominos Register)
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["Username"].Value = null;
            return Redirect("LoginPage");
        }
        
    }
}