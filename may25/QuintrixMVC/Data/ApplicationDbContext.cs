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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PiddlyThing>()
            .HasData(
                new PiddlyThing { Id = Guid.NewGuid(), Name = "Trash 1" },
                new PiddlyThing { Id = Guid.NewGuid(), Name = "Trash 2" },
                new PiddlyThing { Id = Guid.NewGuid(), Name = "Trash 3" },
                new PiddlyThing { Id = Guid.NewGuid(), Name = "Trash 4" }
            );

        modelBuilder.Entity<ValuableThing>()
            .HasData(
                new ValuableThing { Id = Guid.NewGuid(), Name = "Shiny Rock", Value = (decimal)5_000_000.00, Description = "A very shiny rock." },
                new ValuableThing { Id = Guid.NewGuid(), Name = "Jam Jar", Value = (decimal)5_000_000.00, Description = "A jar of raspberry jam." },
                new ValuableThing { Id = Guid.NewGuid(), Name = "Barrel", Value = (decimal)5_000_000.00, Description = "Sail boat suitable for Niagra Falls." },
                new ValuableThing { Id = Guid.NewGuid(), Name = "Mr. Goodpart", Value = (decimal)5_000_000.00, Description = "The comb of Wongo Tigmeus the Third" },
                new ValuableThing { Id = Guid.NewGuid(), Name = "Trade Secret", Value = (decimal)5_000_000.00, Description = "Your mother's phone number." }
            );
    }

    public DbSet<QuintrixMVC.Models.User>? User { get; set; }

    public DbSet<QuintrixMVC.Models.PiddlyThing>? PiddlyThing { get; set; }

    public DbSet<QuintrixMVC.Models.ValuableThing>? ValuableThing { get; set; }
}
