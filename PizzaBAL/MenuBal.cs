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



    }
}
