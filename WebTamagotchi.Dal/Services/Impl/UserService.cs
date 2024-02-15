using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Constants;
using WebTamagotchi.Dal.Entity;
using WebTamagotchi.Dal.Exceptions;

namespace WebTamagotchi.Dal.Services.Impl;

public class UserService : IUserService
{
    private readonly WebTamagotchiDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager, WebTamagotchiDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    public async Task MakePlayer(User user)
    {
        var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email)
                       ?? throw new UserNotFoundException(user.Email);

        await _userManager.RemoveFromRoleAsync(findUser, UserRoles.Administrator);
        await _userManager.AddToRoleAsync(findUser, UserRoles.Player);
    }

    public async Task MakeAdministrator(User user)
    {
        var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email)
                       ?? throw new UserNotFoundException(user.Email);
        
        await _userManager.RemoveFromRoleAsync(findUser, UserRoles.Player);
        await _userManager.AddToRoleAsync(findUser, UserRoles.Administrator);
    }
}