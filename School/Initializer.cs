using Microsoft.Extensions.DependencyInjection;
using School.DAL.Interface;
using School.DAL.Storage;
using School.Domain;
using School.Domain.ModelsDb;
using School.Service.Interface;
using School.Service.Interface1;
using School.Service.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseStorage<UserDb>, UserStorage>();
            services.AddScoped<IBaseStorage<CategoryDb>, CategoryStorage>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryProductsService, CategoryProductsService>();
            services.AddControllersWithViews()
                    .AddDataAnnotationsLocalization()
                    .AddViewLocalization();
        }
    }

}
