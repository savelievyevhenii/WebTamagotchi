using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal;

public class WebTamagotchiDbContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public WebTamagotchiDbContext(DbContextOptions<WebTamagotchiDbContext> options) : base(options)
    {
    }
}