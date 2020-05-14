using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaBAL;
using PizzaDAL;
using DTO;
using System.Web.Http.Cors;

namespace DominosProject.Controllers
{
    [EnableCors("*","*","*")]
    public class PizzaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPizza()
        {
            MenuBal mb = new MenuBal();
            var pizza = mb.GetAllPizzas();
            return Ok(pizza);
        }
        
        [HttpPost]
        public IHttpActionResult PostOrder([FromBody]pizzaDto[] pd)
        {
            //pizzaBAL.CreateOrder(cart);
            return Ok(pd);
        }

    }
}
