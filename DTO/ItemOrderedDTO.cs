using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemOrderedDTO
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProductId { get; set; }

        public virtual newMenuDto Menu { get; set; }
       // public virtual OrderDTO Order { get; set; }
        public virtual PricesDto Price { get; set; }
    }
}
