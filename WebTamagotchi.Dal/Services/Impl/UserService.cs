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
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task UpdateUserRole(User user, string fromRole ,string toRole)
    {
        var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email)
                       ?? throw new UserNotFoundException(user.Email);
        var roles = await _userManager.GetRolesAsync(user);
        
        await _userManager.RemoveFromRoleAsync(findUser, fromRole);
        await _userManager.AddToRoleAsync(findUser, toRole);
    }
}