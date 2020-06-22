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
using DominosProject.filter;

namespace DominosProject.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/Pizza")]
   // [CustomFilters]
    public class PizzaController : ApiController
    {
      

        /// <summary>
        /// This method will retrieve all pizza information
        /// by calling business layer method.
        /// </summary>
        /// <returns></returns>
        [HttpGet][Route("GetPizza")]
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
        /// <param name="Username></param>
        /// <returns></returns>
        [HttpPost][Route("PostOrder")]
        public IHttpActionResult PostOrder([FromBody]string Username)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.SaveOrder(Username);
            menuBalObj.EmptyCart();
            return Ok();
        }

        /// <summary>
        /// This method will save cart data into DB
        /// by calling buisness layer method.
        /// </summary>
        /// <param name="cartObj"></param>
        /// <returns></returns>
        [HttpPost][Route("AddCart")]
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
        [HttpGet][Route("GetAllCartData")]
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
        [HttpPut][Route("IncreaseItemFromCart/{id}")]
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
        [HttpDelete][Route("DecreaseItemFromCart/{id}")]
        public IHttpActionResult DecreaseItemFromCart(int id)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.DecreaseCartData(id);
            return Ok();
        }

        [HttpGet]
        [Route("OrderHistoryData")]
        public IHttpActionResult OrderHistoryData([FromUri]string Username)
        {
            // DominosEntities5 context = new DominosEntities5();
          //  MenuDAL obj = new MenuDAL();
            MenuBal menuBalObj = new MenuBal();
            var pizza = menuBalObj.OrderHistory(Username);
            return Ok(pizza);
        }

        [HttpPost]
        [Route("AddToMenu")]
        public IHttpActionResult AddToMenu([FromBody] AdMenuDto addMenu)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.AddToMenu(addMenu);
            return Ok();

        }
        [HttpDelete]
        [Route("RemoveFromMenu/{menuId}")]
        public IHttpActionResult RemoveFromMenu(int menuId)
        {
            MenuBal menuBalObj = new MenuBal();
            menuBalObj.DeleteFromMenu(menuId);
            return Ok();
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public IHttpActionResult GetUserDetails([FromUri]string Username)
        {

            UserLoginBAL userBalObj = new UserLoginBAL();
            var pizza = userBalObj.GetUserDetail(Username);
            return Ok(pizza);
        }
    }
}
