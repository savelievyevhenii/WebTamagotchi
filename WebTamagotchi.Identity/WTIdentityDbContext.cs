using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity
{
    public class WTIdentityDbContext : IdentityUserContext<User>
    {
        private readonly IConfiguration _configuration;

        public WTIdentityDbContext(DbContextOptions<WTIdentityDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedAdminUser(modelBuilder);
        }

        private static void SeedAdminUser(ModelBuilder modelBuilder)
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
    }
}