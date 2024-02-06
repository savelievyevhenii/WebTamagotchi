using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal;

public class WebTamagotchiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public WebTamagotchiDbContext()
    {
    }

    public WebTamagotchiDbContext(DbContextOptions<WebTamagotchiDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
    }
}