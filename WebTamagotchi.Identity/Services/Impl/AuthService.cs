using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Identity.Enums;
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

    public async Task<AuthRequest> Register(RegistrationRequest request)
    {
        var user = new ApplicationUser { UserName = request.Email, Email = request.Email, Role = Role.Player };
    
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
}