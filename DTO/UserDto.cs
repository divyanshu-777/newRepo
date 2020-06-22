using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }


        //  public virtual ICollection<OrderDTO> Orders { get; set; }

        // public virtual ICollection<CartDTO> Carts { get; set; }
    }
}
