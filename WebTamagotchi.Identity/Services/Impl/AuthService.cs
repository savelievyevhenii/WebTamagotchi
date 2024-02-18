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

    public async Task<AuthResponse> Authenticate(AuthRequest request)
    {
        var managedUser = await _userManager.FindByEmailAsync(request.Email!) ??
                          throw new UserNotFoundException(request.Email!);

        if (!await _userManager.CheckPasswordAsync(managedUser, request.Password!))
        {
            throw new PasswordValidationException();
        }

        var foundUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);

        if (foundUser is null)
        {
            throw new UnauthorizedAccessException();
        }

        var accessToken = _tokenService.CreateToken(foundUser);
        var refreshToken = _tokenService.GenerateRefreshToken(foundUser);

        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            Username = foundUser.UserName,
            Email = foundUser.Email!,
            Token = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthRequest> Register(RegistrationRequest request)
    {
        var user = new User { UserName = request.Email, Email = request.Email, Role = Role.Player };

        var result = await _userManager.CreateAsync(user, request.Password!);

        if (result.Succeeded)
        {
            return new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            };
        }

        var firstErrorDescription = result.Errors.FirstOrDefault()?.Description ?? "Registration failed.";
        throw new Exception(firstErrorDescription);
    }

    public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
    {
        if (tokenModel is null)
        {
            throw new InvalidClientRequestException();
        }

        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken)
                        ?? throw new InvalidTokenException();

        var user = await _userManager.FindByNameAsync(principal.Identity!.Name!)
                   ?? throw new InvalidTokenException();

        if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new InvalidTokenException();
        }

        var newAccessToken = _tokenService.CreateToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken(user);

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        var result = new
        {
            accessToken = newAccessToken,
            refreshToken = newRefreshToken
        };

        return new ObjectResult(result);
    }
    
    public async Task Revoke(string username)
    {
        var user = await _userManager.FindByNameAsync(username)
                   ?? throw new UserNotFoundException(username);

        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);
    }

    public async Task RevokeAll()
    {
        var users = _userManager.Users.ToList();
        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }
    }
}