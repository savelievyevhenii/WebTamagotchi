using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Exceptions;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services.Impl;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    private async Task<User> GetUserByEmailAndRoleAsync(string email, Role role)
    {
        var user = await _userManager.FindByEmailAsync(email)
                   ?? throw new UserNotFoundException(email);

        if (user.Role == role)
        {
            return user;
        }

        var exceptionType = role == Role.Admin
            ? typeof(UserNotAdminException)
            : typeof(UserNotPlayerException);

        throw ((Exception)Activator.CreateInstance(exceptionType, email)!)!;
    }

    private async Task<IEnumerable<User>> GetUsersByRoleAsync(Role role)
    {
        var users = _userManager.Users?.Where(user => user.Role == role)
                    ?? throw new Exception("Unable to retrieve users.");

        return await Task.FromResult(users);
    }

    public async Task<IEnumerable<User>> GetPlayers() => await GetUsersByRoleAsync(Role.Player);

    public async Task<User> GetPlayer(string email) => await GetUserByEmailAndRoleAsync(email, Role.Player);

    public async Task DeletePlayer(string email) => await _userManager.DeleteAsync(await GetPlayer(email));

    public async Task<IEnumerable<User>> GetAdmins() => await GetUsersByRoleAsync(Role.Admin);

    public async Task<User> GetAdmin(string email) => await GetUserByEmailAndRoleAsync(email, Role.Admin);

    public async Task DeleteAdmin(string email) => await _userManager.DeleteAsync(await GetAdmin(email));

    public async Task<User> ChangeRole(string email, Role role)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
        user.Role = role;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return user;
        }

        var firstErrorDescription = result.Errors.FirstOrDefault()?.Description
                                    ?? "Changing user role failed.";
        throw new Exception(firstErrorDescription);
    }
}