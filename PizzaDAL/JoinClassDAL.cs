using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDAL
{
    public class JoinClassDAL
    {
      public string MenuName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public int Price{ get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int MenuId { get; set; }
    }
}
