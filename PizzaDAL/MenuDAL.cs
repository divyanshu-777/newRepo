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
    }
}
