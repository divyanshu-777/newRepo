using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class OrderDTO
    {
        public int OrderId { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string OrderedBy { get; set; }
        public int OrderAmount { get; set; }

        public virtual ICollection<ItemOrderedDTO> ItemOrdereds { get; set; }
        public virtual UserDto User { get; set; }
    }
}
