using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            options.UseSqlite(config.GetConnectionString("DefaultConnection") ??
                throw new KeyNotFoundException("Could not retrieve DefaultConnection from configuration."));
        }

        public DbSet<JwtApi.Models.User> Users { get; set; }
    }
}