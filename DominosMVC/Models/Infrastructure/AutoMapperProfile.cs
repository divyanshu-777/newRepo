using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DominosMVC.Models;

namespace DominosMVCProject.Models.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdminLogin, LoginDto>();
        }
    }
}