using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class menu
    {
        public List<tblMenu> Getdata()
        {
            using (DominosDbEntities context = new DominosDbEntities())
            {

                var pizza = context.tblMenus.ToList();
                return pizza;
            }
            
        }
    }
}
