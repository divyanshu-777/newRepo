using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BAL
{
    public class menuBal
    {
        menu mn = new menu();

        public List<tblMenu> GetData()
        {
           
            var data = mn.Getdata();
            return data;
        }
    }
}
