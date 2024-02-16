using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity
{
    public class WTIdentityDbContext : IdentityUserContext<ApplicationUser>
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

            // SeedAdminUser(modelBuilder);
        }

        private void SeedAdminUser(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminEmail = _configuration.GetValue<string>("SiteSettings:AdminEmail");
            var adminPassword = _configuration.GetValue<string>("SiteSettings:AdminPassword");

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111", // primary key
                    UserName = "admin",
                    NormalizedUserName = adminEmail.ToUpper(),
                    PasswordHash = hasher.HashPassword(null, adminPassword),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    Role = Role.Admin
                }
            );
        }
    }
}