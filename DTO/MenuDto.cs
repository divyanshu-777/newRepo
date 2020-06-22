using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class MenuDto
    {

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PricesDto> Prices { get; set; }

    }
}