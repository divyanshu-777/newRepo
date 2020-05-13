using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDAL;
namespace PizzaBAL
{
    public class MenuBal
    {
        MenuDAL pizzaDAL;

        public MenuBal()
        {
            pizzaDAL = new MenuDAL();
        }
        public List<Menu> GetAllPizzas()
        {
            return pizzaDAL.GetAllPizzas();
        }
    }
}
