using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuintrixMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<QuintrixMVC.Models.Player>? Players { get; set; }

    public DbSet<QuintrixMVC.Models.Robot>? Robot { get; set; }

}
