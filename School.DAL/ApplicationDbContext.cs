using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.Domain.ModelsDb;

namespace School.DAL
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<UserDb> userDb { get; set; }

        public DbSet<CategoryDb> CategoryDb { get; set; }

        public DbSet<OrdersDb> OrdersDb { get; set; }

        public DbSet<PictureProductDb> PictureProductDb { get; set; }

        public DbSet<ProductsDb> ProductsDb { get; set; }

        public DbSet<RequestDb> RequestDb { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
       

    }
}
