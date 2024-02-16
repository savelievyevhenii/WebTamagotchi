using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebTamagotchi.Identity.Exceptions;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services.Impl;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly WTIdentityDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<ApplicationUser> userManager, WTIdentityDbContext context,
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

        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            Username = foundUser.UserName,
            Email = foundUser.Email!,
            Token = accessToken
        };
    }


    public Task<AuthResponse> Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}