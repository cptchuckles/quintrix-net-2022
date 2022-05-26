using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuintrixMVC.Models;

namespace QuintrixMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<QuintrixMVC.Models.User>? User { get; set; }

    public DbSet<QuintrixMVC.Models.PiddlyThing>? PiddlyThing { get; set; }

    public DbSet<QuintrixMVC.Models.ValuableThing>? ValuableThing { get; set; }
}
