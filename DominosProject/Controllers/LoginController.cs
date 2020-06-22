using AutoMapper;
using DominosProject.Models;
using DTO;
using PizzaBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DominosProject.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Login")]
   
    public class LoginController : ApiController
    {

        [HttpPost]
         [Route("LoginUser")]
        public HttpResponseMessage LoginUser(LoginDto user)
        {

            UserLoginBAL mb = new UserLoginBAL();
            LoginDto ld = new LoginDto();
            var ur = mb.CheckUser(user);

            if (ur == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "The user was not found.");

            return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(user.Username));
        }



        /// <summary>
        /// this method will save user credentials 
        /// by calling buisness layer method.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUp")]
        public IHttpActionResult SignUp([FromBody]RegisterUserDto register)
        {
            UserLoginBAL userBalObj = new UserLoginBAL();
            userBalObj.AddUser(register);
            return Ok();
        }


        [HttpGet]
        [Route("Validate")]
        public HttpResponseMessage Validate(string token, string username)
        {
            UserLoginBAL mb = new UserLoginBAL();
           var usr= mb.VerifyUsername(username);
            if (usr == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "The user was not found.");

            string tokenUsername = TokenManager.ValidateToken(token);
            if (username.Equals(tokenUsername))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
