using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DominosProject.Models
{
    public class pizzaclass
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
    }




    public class pizzass
    {
        public List<pizzaclass> li  { get; set; }
    }
}