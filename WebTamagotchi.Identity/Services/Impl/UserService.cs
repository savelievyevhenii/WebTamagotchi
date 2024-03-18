using CSharpFunctionalExtensions;
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

    public async Task<Result<User>> GetPlayer(string email) => await GetUserByEmailAndRoleAsync(email, Role.Player);

    public async Task<Result<User>> GetAdmin(string email) => await GetUserByEmailAndRoleAsync(email, Role.Admin);

    private async Task<Result<User>> GetUserByEmailAndRoleAsync(string email, Role role)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return Result.Failure<User>(new UserNotFoundException(email).ToString());
        }

        if (user.Role == role)
        {
            return Result.Success(user);
        }

        var errorMessage = role == Role.Admin
            ? new UserNotAdminException(email).ToString()
            : new UserNotPlayerException(email).ToString();

        return Result.Failure<User>(errorMessage);
    }

    public async Task<Result> DeletePlayer(string email)
    {
        var result = await GetPlayer(email);

        if (!result.IsSuccess)
        {
            return result;
        }

        return await _userManager.DeleteAsync(result.Value) != null
            ? Result.Success()
            : Result.Failure("Deletion failed");
    }

    public async Task<Result> DeleteAdmin(string email)
    {
        var result = await GetAdmin(email);

        if (!result.IsSuccess)
        {
            return result;
        }

        return await _userManager.DeleteAsync(result.Value) != null
            ? Result.Success()
            : Result.Failure("Deletion failed");
    }

    public async Task<Result<User>> ChangeRole(string email, Role role)
    {
        return await Result.Try(() => _userManager.FindByEmailAsync(email))
            .Bind(async user =>
            {
                if (user == null)
                    return Result.Failure<User>(new UserNotFoundException(email).ToString());

                user.Role = role;

                var updateResult = await _userManager.UpdateAsync(user);

                return updateResult.Succeeded
                    ? Result.Success(user)
                    : Result.Failure<User>(updateResult.Errors.FirstOrDefault()?.Description ??
                                           "Changing user role failed.");
            });
    }
}