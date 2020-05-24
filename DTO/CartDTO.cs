using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CartDTO
    {
        public int CartId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public string OrderedBy { get; set; }
        public int ProductId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }

    }
}
