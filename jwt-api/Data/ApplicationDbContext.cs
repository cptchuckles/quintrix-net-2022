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
            
            string connectionName;
            switch (Environment.GetEnvironmentVariable("ASPNET_ENVIRONMENT"))
            {
            case "production":
                connectionName = "ProductionConnection";
                break;
            default:
                connectionName = "DevelopmentConnection";
                break;
            }

            options.UseSqlite(config.GetConnectionString(connectionName) ??
                throw new KeyNotFoundException($"Could not retrieve {connectionName} from configuration."));
        }

        public DbSet<JwtApi.Models.User>? Users { get; set; }
    }
}