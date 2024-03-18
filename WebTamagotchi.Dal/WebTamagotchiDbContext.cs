using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebTamagotchi.GameLogic.Models;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Dal;

public class WebTamagotchiDbContext : IdentityUserContext<User>
{
    public DbSet<Pet> Pets { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Food> Foods { get; set; }

    public DbSet<Bedroom> Bedrooms { get; set; }

    public DbSet<Bathroom> Bathrooms { get; set; }

    private readonly IConfiguration _configuration;

    public WebTamagotchiDbContext(DbContextOptions<WebTamagotchiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity => { entity.HasIndex(x => x.Name).IsUnique(); });
        modelBuilder.Entity<Food>(entity => { entity.HasIndex(x => x.Name).IsUnique(); });
        modelBuilder.Entity<Bedroom>(entity => { entity.HasIndex(x => x.Name).IsUnique(); });
        modelBuilder.Entity<Bathroom>(entity => { entity.HasIndex(x => x.Name).IsUnique(); });

        SeedData.SeedAdminUser(modelBuilder);
    }
}