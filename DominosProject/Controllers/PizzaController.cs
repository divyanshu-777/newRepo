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
            menuBalObj.EmptyCart();
            return Ok();
        }

        /// <summary>
        /// This method will save cart data into DB
        /// by calling buisness layer method.
        /// </summary>
        /// <param name="cartObj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddCart([FromBody] CartDTO cartObj)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.AddToCart(cartObj);
            return Ok();
        }

        /// <summary>
        /// This method will retrieve all cart data
        /// from DB by calling buisness layer method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllCartData()
        {
            MenuBal menuBalObj = new MenuBal();
            var pizza = menuBalObj.GetCartDatas();
            return Ok(pizza);
        }

        /// <summary>
        /// This method will increase cart item in the cart
        /// by calling buisness layer method in DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult IncreaseItemFromCart(int id)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.UpdateCartData(id);
            return Ok();
        }

        /// <summary>
        /// This method will decrease cart item in the cart
        /// by calling buisness layer method in DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DecreaseItemFromCart(int id)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.DecreaseCartData(id);
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
