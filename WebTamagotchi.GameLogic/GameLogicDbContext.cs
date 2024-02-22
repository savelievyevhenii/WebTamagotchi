using Microsoft.EntityFrameworkCore;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic;

public class GameLogicDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Food> Foods { get; set; }

    public DbSet<Bedroom> Bedrooms { get; set; }

    public DbSet<Bathroom> Bathrooms { get; set; }

    public GameLogicDbContext(DbContextOptions<GameLogicDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedFood(modelBuilder);
        SeedGames(modelBuilder);
        SeedBedrooms(modelBuilder);
        SeedBathrooms(modelBuilder);
    }

    private static void SeedFood(ModelBuilder modelBuilder)
    {
        var apple = new Food
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Apple",
            Experience = 10,
            Satiety = 10,
            Dirtiness = 6,
        };

        var soup = new Food
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Soup",
            Experience = 20,
            Satiety = 26,
            Dirtiness = 12,
        };

        modelBuilder.Entity<Food>().HasData(apple);
        modelBuilder.Entity<Food>().HasData(soup);
    }

    private static void SeedGames(ModelBuilder modelBuilder)
    {
        var game = new Game
        {
            Id = Guid.NewGuid().ToString(),
            Name = "TestGame",
            Experience = 20,
            Fun = 10,
            Hunger = 16,
            Dirtiness = 10,
            Tiredness = 20
        };

        modelBuilder.Entity<Game>().HasData(game);
    }

    private static void SeedBedrooms(ModelBuilder modelBuilder)
    {
        var standardBedroom = new Bedroom
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Standard Bedroom",
            Experience = 20,
            Energy = 20
        };

        modelBuilder.Entity<Bedroom>().HasData(standardBedroom);
    }

    private static void SeedBathrooms(ModelBuilder modelBuilder)
    {
        var standardBathroom = new Bathroom
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Standard Bathroom",
            Experience = 20,
            Cleanliness = 20
        };

        modelBuilder.Entity<Bathroom>().HasData(standardBathroom);
    }
}