using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using PizzaDAL;
using AutoMapper;

namespace PizzaBAL.AutoMapper
{
    /// <summary>
    /// This class is responsible for mapping 
    /// two diffrent classes which are in diffrent
    /// library.
    /// </summary>
    class LoginMapper
    {
        /// <summary>
        /// This method will map User class with
        /// LoginDto class.
        /// </summary>
        /// <param name="UserObj"></param>
        /// <returns></returns>
        public LoginDto LoginMapReverse(User UserObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, LoginDto>();
            });
            var mapper = configuration.CreateMapper();
            var LoginDtoObj = mapper.Map<LoginDto>(UserObj);
            return LoginDtoObj;
        }

        /// <summary>
        /// This method will map LoginDto class with
        /// User class.
        /// </summary>
        /// <param name="loginObj"></param>
        /// <returns></returns>
        public User LoginMap(LoginDto loginObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginDto,User>();
            });
            var mapper = configuration.CreateMapper();
            var UserObj = mapper.Map<User>(loginObj);
            return UserObj;
        }


    }
}
