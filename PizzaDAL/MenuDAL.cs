using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace PizzaDAL
{

    /// <summary>
    /// This class is responsible for interacting with database.
    /// It will allow user to perform CRUD operations.
    /// </summary>
    public class MenuDAL
    {
       
        DominosEntities2 context;
        /// <summary>
        /// Intialization of Model object 
        /// </summary>
        public MenuDAL()
        {
            context = new DominosEntities2();
        }
        /// <summary>
        /// This method will retrieve all the Menu table information
        /// along with prices from database.
        /// </summary>
        public List<Menu> GetAllPizzas()
        {
            var pizza = context.Menus.Include(m => m.Prices).ToList();
            return pizza;
        }
        /// <summary>
        /// This method will check the login credentials 
        /// from the database.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User CheckUser(User login)
        {
             var ur = context.Users.Where(x => x.UserName ==login.UserName && x.Password == login.Password).FirstOrDefault();
            return ur;
        }
        /// <summary>
        /// This method will add the login credentials 
        /// into the database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        /// <summary>
        /// This method will save the order history
        /// details into the database.
        /// </summary>
        /// <param name="orderObj"></param>
        /// <param name="itemOrderedObj"></param>
        public void SaveOrder(Order orderObj, List<ItemOrdered> itemOrderedObj)
        {
            var returnedObj = context.Orders.Add(orderObj);
            foreach (var item in itemOrderedObj)
            {
                item.OrderId = returnedObj.OrderId;
                context.ItemOrdereds.Add(item);
            }
            context.SaveChanges();
        }
    }
}
