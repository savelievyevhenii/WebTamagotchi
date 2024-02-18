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
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = _userManager.Users ?? throw new Exception("Unable to retrieve users.");

        return await Task.FromResult(users);
    }


    public async Task<User> GetUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);

        return user;
    }

    public async Task DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            var firstErrorDescription = result.Errors.FirstOrDefault()?.Description ?? "Deleting user failed.";
            throw new Exception(firstErrorDescription);
        }
    }

    public async Task<User> ChangeRole(string email, Role role)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
        user.Role = role;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            var firstErrorDescription = result.Errors.FirstOrDefault()?.Description ?? "Changing user role failed.";
            throw new Exception(firstErrorDescription);
        }

        return user;
    }
}