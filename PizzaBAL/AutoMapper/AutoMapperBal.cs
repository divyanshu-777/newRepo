using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using AutoMapper;
using PizzaDAL;
namespace PizzaBAL.AutoMapper
{
    class AutoMapperBal : Profile
    {
        public AutoMapperBal()
        {

           CreateMap<LoginDto, User>();
           
        }

    }
}
