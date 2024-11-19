using Microsoft.Extensions.DependencyInjection;
using School.DAL.Interface;
using School.DAL.Storage;
using School.Domain;
using School.Domain.ModelsDb;
using School.Service;
using School.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection service)
        {
            service.AddScoped<IBaseStorage<UserDb>, UserStorage>();

        }

        public static void InitializeServies(this IServiceCollection service)
        {
            service.AddScoped<IAccountService, AccountService>();
            service.AddControllersWithViews()
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();
        }
    }
}
