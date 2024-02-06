using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal.Services.Impl;

public class UserService : IUserService
{
    private readonly WebTamagotchiDbContext _context;

    public UserService(WebTamagotchiDbContext context)
    {
        _context = context;
    }
    
    public async Task Insert(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}