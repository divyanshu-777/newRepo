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
    /// two different classes which are in different
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


        /// <summary>
        /// This method will map CartDto class with
        /// cart class. 
        /// </summary>
        /// <param name="cartObj"></param>
        /// <returns></returns>
        public Cart cartMapper(CartDTO cartObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartDTO, Cart>();
                
            });
            var mapper = configuration.CreateMapper();
            var cartDtoObj = mapper.Map<Cart>(cartObj);
            return cartDtoObj;
        }


        /// <summary>
        /// This method will map JoinclassDal class
        /// to JoinclassDto.
        /// </summary>
        /// <param name="joinObj"></param>
        /// <returns></returns>
        public JoinClassDto JoinMapper(JoinClassDAL joinObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JoinClassDAL, JoinClassDto>();
            });
            var mapper = configuration.CreateMapper();
            var joinDtoObj = mapper.Map<JoinClassDto>(joinObj);
            return joinDtoObj;
        }

        

    }
}
