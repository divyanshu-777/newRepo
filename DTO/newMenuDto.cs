using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class newMenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PricesDto> Prices { get; set; }
      //  public virtual ICollection<CartDTO> Carts { get; set; }
       // public virtual ICollection<ItemOrderedDTO>ItemOrdereds { get; set; }
    }
}
