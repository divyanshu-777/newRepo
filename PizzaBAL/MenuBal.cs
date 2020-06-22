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
        public void SaveOrder(string Username)
        {
            var CartData = pizzaDAL.GetCartData();
            double totalAmount = new double();
            List<ItemOrdered> ListitemOrdered = new List<ItemOrdered>();
            foreach (var item in CartData)
            {
                totalAmount += item.Price;
                ListitemOrdered.Add(new ItemOrdered { MenuId = item.MenuId, Quantity = item.Quantity, ProductId=item.ProductId});
            }
            var orderObj = new Order
            {
                OrderTime = DateTime.Now,
                OrderedBy = Username,
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
            pizzaDAL.RemoveCartData(id);
        }

        /// <summary>
        ///  This method will call data layer method 
        ///  for removing all items from cart in DB.
        /// </summary>
        public void EmptyCart()
        {
            pizzaDAL.EmptyCart();
        }

        //public List<OrderHistoryDto> OrderHistory(string username)
        //{
        //    var data = pizzaDAL.OrderHistoryData(username);
        //    List<OrderHistoryDto> Orderobj = new List<OrderHistoryDto>();
        //    foreach (var items in data)
        //    {
        //        Orderobj.Add(pizzaMapper.JoinMapperOrderHistory(items));
        //    }
        //    return Orderobj;
        //}

        public List<OrderDTO> OrderHistory(string username)
        {
           // DominosEntities5 context = new DominosEntities5();
             var data = pizzaDAL.OrderHistoryData(username);
            //  var data = context.Orders.Where(ord => ord.OrderedBy == username).ToList();
            List<OrderDTO> ordObj = new List<OrderDTO>();
            foreach (var items in data)
            {
                ordObj.Add(pizzaMapper.MapperOrderHistory(items));
            }
            return ordObj;
           // return data;
        }

        public void AddToMenu(AdMenuDto addmenuObj)
        {
            var menuobj = new Menu
            {
                MenuName = addmenuObj.MenuName,
                Description=addmenuObj.Description,
                Category=addmenuObj.Category
            };
            var priceObj = new Price
            {
                Size=addmenuObj.Size,
                PriceOfProduct=addmenuObj.Price
            };

            pizzaDAL.AddToMenus(menuobj, priceObj);
        }

        public void DeleteFromMenu(int menuid)
        {
            pizzaDAL.DeleteFromMenu(menuid);
        }

       
    }
}
