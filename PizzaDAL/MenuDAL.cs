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
            var ur = context.Users.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
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

        /// <summary>
        /// This method will add cart data
        /// into database.
        /// </summary>
        /// <param name="cart"></param>
        public void AddToCart(Cart cart)
        {

            var cartItem = context.Carts.SingleOrDefault(c => c.ProductId == cart.ProductId);
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    MenuId = cart.MenuId,
                    ProductId = cart.ProductId,
                    Quantity = 1,
                    OrderedBy = cart.OrderedBy
                };
                context.Carts.Add(cartItem);
            }

            else
            {
                cartItem.Quantity++;
            }
            context.SaveChanges();
        }

       /// <summary>
       /// This method will update the changes made 
       /// in the cart by the user in database.
       /// </summary>
       /// <param name="id"></param>
        public void UpdateCart(int id)
        {
            var cartItem = context.Carts.Single(c => c.ProductId == id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
                context.SaveChanges();
            }

        }

        /// <summary>
        /// This method will decrement cart data
        /// in the cart. 
        /// </summary>
        /// <param name="id"></param>
        public void DecreaseCartData(int id)
        {
            var cartItem = context.Carts.Single(c => c.ProductId == id);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    context.Carts.Remove(cartItem);
                }
                context.SaveChanges();
            }

        }

        /// <summary>
        /// This method will remove all the cart item
        ///  from the cart after the order is placed.
        /// </summary>
        public void EmptyCart()
        {
            var cartItems = context.Carts.ToList();
                

            foreach (var Item in cartItems)
            {
                context.Carts.Remove(Item);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// This method will display all the cart data
        /// present in  database.
        /// </summary>
        /// <returns></returns>
        public List<JoinClassDAL> GetCartData()
        {
            List<Cart> cart = context.Carts.ToList();
            List<Menu> menu = context.Menus.ToList();
            List<Price> price = context.Prices.ToList();
            var query = (from c in cart
                        join mn in menu on c.MenuId equals mn.MenuId into table1
                        from mn in table1.DefaultIfEmpty()

                        join pr in price on c.ProductId equals pr.ProductId into table2
                        from pr in table2.DefaultIfEmpty()
                        select new JoinClassDAL
                        {
                            MenuName = mn.MenuName,
                            Description = mn.Description,
                            Size = pr.Size,
                            Price = pr.PriceOfProduct,
                            Image = mn.Image,
                            Quantity= c.Quantity,
                            ProductId=c.ProductId,
                            MenuId=c.MenuId
                        }).ToList();

            return query;


        }

    }
}
