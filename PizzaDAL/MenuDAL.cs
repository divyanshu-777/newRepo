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
        /// <summary>
        /// This method will retrieve all the Menu table information
        /// along with prices from database.
        /// </summary>
        public List<Menu> GetAllPizzas()
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var pizza = context.Menus.Include(m => m.Prices).ToList();
                    return pizza;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return null;
                }
            }
        }
        /// <summary>
        /// This method will check the login credentials 
        /// from the database.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User CheckUser(User login)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var user = context.Users.SingleOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
                    return user;
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return null;
                }
            }
        }

        public Admin CheckAdmin(Admin login)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var user = context.Admins.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);
                    return user;
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// This method will add the login credentials 
        /// into the database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }


        public string VerifyUsername(string username)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                var data = context.Users.SingleOrDefault(x => x.UserName == username);
                return data.UserName;
            }
        }
        /// <summary>
        /// This method will save the order history
        /// details into the database.
        /// </summary>
        /// <param name="orderObj"></param>
        /// <param name="itemOrderedObj"></param>
        public void SaveOrder(Order orderObj, List<ItemOrdered> itemOrderedObj)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var returnedObj = context.Orders.Add(orderObj);
                    foreach (var item in itemOrderedObj)
                    {
                        item.OrderId = returnedObj.OrderId;
                        context.ItemOrdereds.Add(item);
                    }
                    context.SaveChanges();
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// This method will add cart data
        /// into database.
        /// </summary>
        /// <param name="cart"></param>
        public void AddToCart(Cart cart)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
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
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// This method will update the changes made 
        /// in the cart by the user in database.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCart(int id)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var cartItem = context.Carts.Single(c => c.ProductId == id);
                    if (cartItem != null)
                    {
                        cartItem.Quantity++;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// This method will decrement cart data
        /// in the cart. 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCartData(int id)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
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
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// This method will remove all the cart item
        ///  from the cart after the order is placed.
        /// </summary>
        public void EmptyCart()
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
                {
                    var cartItems = context.Carts.ToList();

                    foreach (var Item in cartItems)
                    {
                        context.Carts.Remove(Item);
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// This method will display all the cart data
        /// present in  database.
        /// </summary>
        /// <returns></returns>
        public List<JoinClassDAL> GetCartData()
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                try
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
                                     Quantity = c.Quantity,
                                     ProductId = c.ProductId,
                                     MenuId = c.MenuId
                                 }).ToList();

                    return query;

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return null;
                }
            }
        }

        public List<Order> OrderHistoryData(string username)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                var order = context.Orders.Where(ord => ord.OrderedBy == username).ToList();
                return order;
                    }
        }

        public void AddToMenus( Menu menuObj,Price priceObj)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                var returnObj = context.Menus.Add(menuObj);

                priceObj.MenuId = returnObj.MenuId;
                context.Prices.Add(priceObj);
                context.SaveChanges();
            }
        }

        public void DeleteFromMenu(int menuid)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                var menuitem = context.Menus.Single(x => x.MenuId == menuid);
                var priceitem = context.Prices.Single(x => x.MenuId == menuid);
                if(menuitem!=null && priceitem!=null)
                {
                    context.Menus.Remove(menuitem);
                    context.Prices.Remove(priceitem);
                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public User GetUserDetail(string Username)
        {
            using (DominosEntities5 context = new DominosEntities5())
            {
                var details = context.Users.SingleOrDefault(x => x.UserName == Username);
                return details;
            }
        }
        //    public List<OrderHistoryDAL> OrderHistoryData(string username)
        //{
        //    using (DominosEntities2 context = new DominosEntities2())
        //    {
        //        List<Order> order = context.Orders.Where(x => x.OrderedBy == username).ToList();
        //        List<ItemOrdered> itemorder = context.ItemOrdereds.ToList();
        //        List<Menu> menu = context.Menus.ToList();

        //        var query = (from i in itemorder
        //                     join o in order on i.OrderId equals o.OrderId
        //                     into table1
        //                     from o in table1.DefaultIfEmpty()

        //                     join mn in menu on i.MenuId equals mn.MenuId
        //                     into table2
        //                     from mn in table2.DefaultIfEmpty()
        //                     select new OrderHistoryDAL
        //                     {
        //                         OrderId = o.OrderId,
        //                         Quantity = i.Quantity,
        //                         MenuName = mn.MenuName,
        //                         OrderTime = o.OrderTime,
        //                         OrderAmount = o.OrderAmount

        //                     }).ToList();
        //        return query;
        //    }

        // }


    }
    
}
