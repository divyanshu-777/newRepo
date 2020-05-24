using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDAL;
using DTO;
using AutoMapper;
using PizzaBAL.AutoMapper;

namespace PizzaBAL
{
    /// <summary>
    /// This is Buisness layer class,responsible for 
    /// intreacting with Data layer classes.
    /// </summary>
    public class MenuBal
    {
        // Intializing AutoMapper class Object.
        MenuMapper pizzaMapper = new MenuMapper();
        MenuDAL pizzaDAL;

        //Intializing PizzaDal class Object.
        public MenuBal()
        {
            pizzaDAL = new MenuDAL();
        }

        /// <summary>
        /// This method will call data layer method 
        /// for retrieveing pizza information from DB.
        /// </summary>
        /// <returns></returns>
        public List<MenuDto> GetAllPizzas()
        {
            var ListMenu = pizzaDAL.GetAllPizzas();
            List<MenuDto> ListMenuDto = new List<MenuDto>();
            foreach (var item in ListMenu)
            {
                ListMenuDto.Add(pizzaMapper.menuMapper(item));
            }
            return ListMenuDto;
        }

        /// <summary>
        ///   This method will call data layer method 
        /// for saving order history information in DB.
        /// </summary>
        /// <param name="Cart"></param>
        public void SaveOrder(List<pizzaDto> Cart)
        {
            double totalAmount = new double();
            List<ItemOrdered> ListitemOrdered = new List<ItemOrdered>();
            foreach (var item in Cart)
            {
                totalAmount += item.Price;
                ListitemOrdered.Add(new ItemOrdered { MenuId = item.MenuId, Quantity = item.Quantity });
            }
            var orderObj = new Order
            {
                OrderTime = DateTime.Now,
                OrderedBy = Cart[0].Order_By,
                OrderAmount = Convert.ToInt32(totalAmount * 1.05d)
            };
            pizzaDAL.SaveOrder(orderObj, ListitemOrdered);
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for adding cart data into database.
        /// </summary>
        /// <param name="cartObj"></param>
        public void AddToCart(CartDTO cartObj)
        {

            pizzaDAL.AddToCart(pizzaMapper.cartMapper(cartObj));
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for displaying all cart data present in DB.
        /// </summary>
        /// <returns></returns>
        public List<JoinClassDto> GetCartDatas()
        {
            var data = pizzaDAL.GetCartData();
            List<JoinClassDto> JoinClassObj = new List<JoinClassDto>();
            foreach (var items in data)
            {
                JoinClassObj.Add(pizzaMapper.JoinMapper(items));
            }
            return JoinClassObj;
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for updating Cart item into DB.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCartData(int id)
        {
            pizzaDAL.UpdateCart(id);
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for decrementing cart item into DB.
        /// </summary>
        /// <param name="id"></param>
        public void DecreaseCartData(int id)
        {
            pizzaDAL.DecreaseCartData(id);
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for removing all items from cart in DB.
        /// </summary>
        public void EmptyCart()
        {
            pizzaDAL.EmptyCart();
        }
    }
}
