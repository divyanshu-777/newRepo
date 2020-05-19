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
    /// <summary>
    /// This class is responsible for mapping 
    /// two diffrent classes which are in diffrent
    /// library.
    /// </summary>
    class MenuMapper : Profile
    {
        /// <summary>
        /// This method will map Menu class with
        /// Menu Dto class and price with PriceDto class. 
        /// </summary>
        /// <param name="MenuObj"></param>
        /// <returns></returns>
        public MenuDto menuMapper(Menu MenuObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<Price, PricesDto>();
            });
            var mapper = configuration.CreateMapper();
            var MenuDtoObj = mapper.Map<MenuDto>(MenuObj);
            return MenuDtoObj;
        }



    }
}
