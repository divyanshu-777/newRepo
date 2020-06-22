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
    /// <summary>
    /// This is Buisness layer class,responsible for 
    /// intreacting with Data layer classes.
    /// </summary>
    public class UserLoginBAL
    {
        MenuDAL pizzaDAL;
        // Intializing AutoMapper class Object.
        LoginMapper loginMapp = new LoginMapper();

        //Intializing PizzaDal class Object.
        public UserLoginBAL()
        {
            pizzaDAL = new MenuDAL();
        }

        /// <summary>
        /// This method will call method of data layer class
        /// to authenticate login credentials from DB.
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public LoginDto CheckUser(LoginDto login)
        {
            var data = pizzaDAL.CheckUser(loginMapp.LoginMap(login));
            var newdata = loginMapp.LoginMapReverse(data);
            return newdata;
        }

        public LoginDto CheckAdmin(LoginDto login)
        {
            var data = pizzaDAL.CheckAdmin(loginMapp.AdminLoginMap(login));
            var newdata = loginMapp.AdminLoginMapReverse(data);
            return newdata;
        }

        public string VerifyUsername(string username)
        {
            return pizzaDAL.VerifyUsername(username);
        }

        /// <summary>
        /// This method will call method of data layer class
        /// to add login credentials of users in DB.
        /// </summary>
        /// <param name="ld"></param>
        public void AddUser(RegisterUserDto login)
        {
            pizzaDAL.AddUser(loginMapp.RegisterMap(login));

        }

        public UserDto GetUserDetail(string username)
        {
            var details = pizzaDAL.GetUserDetail(username);
            //List<UserDto> obj = new List<UserDto>();
            //foreach(var data in details)
            //{
            //    obj.Add(loginMapp.UserDetailMap(data));
            //}
            return loginMapp.UserDetailMap(details);
        }

    }
}
