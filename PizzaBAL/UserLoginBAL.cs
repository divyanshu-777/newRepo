using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDAL;
using DTO;
using AutoMapper;
using PizzaBAL.AutoMapper;

namespace PizzaBAL
{
   public  class UserLoginBAL
    {
        MenuDAL pizzaDAL;
        AutoMapperBal amb = new AutoMapperBal();

        public UserLoginBAL()
        {
            pizzaDAL = new MenuDAL();
        }
        public User CheckUser(LoginDto ld)
        {
            var data= pizzaDAL.CheckUser(Mapper.Map<User>(ld));
            return data;
        }

    }
}
