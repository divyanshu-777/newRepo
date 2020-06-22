using AutoMapper;
using DominosMVC.Models;
using DTO;
using PizzaBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DominosMVC.Controllers
{
    public class JwtAuthenticationController : Controller
    {
        
        public ActionResult Index(AdminLogin data)
        {
            return View();
        }

        public ActionResult RegisterUser(RegisterDominos Register)
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLogin Dominos, string returnurl)
        {
            UserLoginBAL mb = new UserLoginBAL();
           // LoginDto ld = new LoginDto();
            var ur = mb.CheckAdmin(Mapper.Map<LoginDto>(Dominos));
            if (ModelState.IsValid)
            {
                if (ur != null)
                {
                    FormsAuthentication.SetAuthCookie(Dominos.Username, false);
                    Session["uname"] = Dominos.Username;
                    if (returnurl != null)
                        return Redirect(returnurl);
                    else
                    {
                        return Redirect("AdminPages");
                    }
                }
                else
                {
                    ViewBag.Data = "Username or Password is incorrect!";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return Redirect("AdminLogin");
        }


        [Authorize]
        public ActionResult AdminPages()
        {
            return View();
        }

    }
}