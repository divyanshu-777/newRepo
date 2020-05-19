using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class PricesDto
    {
        public int ProductId { get; set; }
        public int MenuId { get; set; }
        public string Size { get; set; }
        public int PriceOfProduct { get; set; }
    }
}
