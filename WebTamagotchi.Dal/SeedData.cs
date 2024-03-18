using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.GameLogic.Models;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Dal;

public static class SeedData
{
    public static void SeedAdminUser(ModelBuilder modelBuilder)
    {
        const string adminEmail = "admin@webtamagotchi.com";
        const string adminPassword = "admin1admin";

        var hasher = new PasswordHasher<User>();
        var adminUser = new User
        {
            Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
            UserName = adminEmail,
            NormalizedUserName = adminEmail!.ToUpper(),
            Email = adminEmail,
            NormalizedEmail = adminEmail.ToUpper(),
            Role = Role.Admin
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, adminPassword!);

        modelBuilder.Entity<User>().HasData(adminUser);
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