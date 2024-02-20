using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Exceptions;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services.Impl;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly WTIdentityDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<User> userManager, WTIdentityDbContext context,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<Result<AuthResponse>> Authenticate(AuthRequest request)
    {
        var managedUser = await _userManager.FindByEmailAsync(request.Email!);
        if (managedUser == null)
        {
            return Result.Failure<AuthResponse>(new UserNotFoundException(request.Email!).ToString());
        }

        if (!await _userManager.CheckPasswordAsync(managedUser, request.Password!))
        {
            return Result.Failure<AuthResponse>(new PasswordValidationException().ToString());
        }

        var foundUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (foundUser == null)
        {
            return Result.Failure<AuthResponse>(new UnauthorizedAccessException().ToString());
        }

        var accessToken = _tokenService.CreateToken(foundUser);
        var refreshToken = _tokenService.GenerateRefreshToken(foundUser);

        await _context.SaveChangesAsync();

        return Result.Success(new AuthResponse
        {
            Username = foundUser.UserName,
            Email = foundUser.Email!,
            Token = accessToken,
            RefreshToken = refreshToken
        });
    }

    public async Task<Result<AuthRequest>> Register(RegistrationRequest request)
    {
        var user = new User { UserName = request.Email, Email = request.Email, Role = Role.Player };

        var result = await _userManager.CreateAsync(user, request.Password!);

        return result.Succeeded
            ? Result.Success(new AuthRequest { Email = request.Email, Password = request.Password })
            : Result.Failure<AuthRequest>(result.Errors.FirstOrDefault()?.Description ?? "Registration failed.");
    }

    public async Task<Result<IActionResult>> RefreshToken(TokenModel tokenModel)
    {
        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

        var userResult = await _userManager.FindByNameAsync(principal?.Identity?.Name!) ??
                         Result.Failure<User>(new InvalidTokenException().ToString());

        return userResult.IsSuccess
            ? Result.Success(ValidateAndUpdateTokens(userResult.Value, refreshToken!))
            : Result.Failure<IActionResult>(new InvalidTokenException().ToString());
    }

    private IActionResult ValidateAndUpdateTokens(User user, string refreshToken)
    {
        if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new InvalidTokenException();
        }

        var newAccessToken = _tokenService.CreateToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken(user);

        user.RefreshToken = newRefreshToken;
        _userManager.UpdateAsync(user).GetAwaiter().GetResult();

        var result = new
        {
            accessToken = newAccessToken,
            refreshToken = newRefreshToken
        };

        return new ObjectResult(result);
    }

    public async Task<Result> Revoke(string username)
    {
        var userResult = await _userManager.FindByNameAsync(username) ??
                         Result.Failure<User>(new UserNotFoundException(username).ToString());

        return userResult.IsSuccess
            ? await RevokeRefreshToken(userResult.Value)
            : Result.Failure(new UserNotFoundException(username).ToString());
    }
    
    public async Task<Result> RevokeAll()
    {
        var users = _userManager.Users.ToList();

        foreach (var user in users)
        { 
            await RevokeRefreshToken(user);
        }

        return Result.Success();
    }
    
    private async Task<Result> RevokeRefreshToken(User user)
    {
        user.RefreshToken = null;
        _userManager.UpdateAsync(user).GetAwaiter().GetResult();

        return Result.Success();
    }
}