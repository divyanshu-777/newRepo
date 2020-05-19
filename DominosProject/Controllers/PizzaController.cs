using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaBAL;
using DTO;
using System.Web.Http.Cors;
using DominosProject.Models;

namespace DominosProject.Controllers
{
    [EnableCors("*","*","*")]
    public class PizzaController : ApiController
    {
        /// <summary>
        /// This method will retrieve all pizza information
        /// by calling business layer method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetPizza()
        {
            MenuBal menuBalObj = new MenuBal();
            var pizza = menuBalObj.GetAllPizzas();
            return Ok(pizza);
        }

        /// <summary>
        /// This method is responsible for saving order
        /// history by calling buisness layer method.
        /// </summary>
        /// <param name="pizzaDtoObj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostOrder([FromBody]List<pizzaDto> pizzaDtoObj)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.SaveOrder(pizzaDtoObj);
            return Ok();
        }

        /// <summary>
        /// this method will save user credentials 
        /// by calling buisness layer method.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SignUp([FromBody]LoginDto login)
        {
            UserLoginBAL userBalObj = new UserLoginBAL();
            userBalObj.AddUser(login);
            return Ok();
        }

    }
}
