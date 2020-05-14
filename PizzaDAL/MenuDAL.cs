using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace PizzaDAL
{
    public class MenuDAL
    {

        DominosEntities context;
        public MenuDAL()
        {
            context = new DominosEntities();
        }
        public List<Menu> GetAllPizzas()
        {
            var pizza = context.Menus.Include(m => m.Prices).ToList();
            return pizza;
        }

        public User CheckUser(User login)
        {
             var ur = context.Users.Where(x => x.UserName ==login.UserName && x.Password == login.Password).FirstOrDefault();
            return ur;
        }
    }
}
