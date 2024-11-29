using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.ViewModels.LoginAndRegistration;

namespace School.Service
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<User, UserDb>().ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, ConfirmEmailViewModel>().ReverseMap();
            CreateMap<User, ConfirmEmailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDb>().ReverseMap();
            CreateMap<Category, CategoryProductsViewModel>().ReverseMap();

        }
    }
}
