using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace School.DAL
{
    public class ApplicationDbContext : DbContex
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
