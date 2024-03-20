using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Infrastructure.TokenManager;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class AuthHandler : IRequestHandler<AuthCommand, Result<AuthResponse, Error>>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenManager _tokenManager;

    public AuthHandler(UserManager<User> userManager, ITokenManager tokenManager)
    {
        _userManager = userManager;
        _tokenManager = tokenManager;
    }
    
    public async Task<Result<AuthResponse, Error>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserValidationError("email_not_valid", $"Invalid user email: {request.Email}");
        }

        if (!await _userManager.CheckPasswordAsync(user, request.Password!))
        {
            return new UserValidationError("password_not_valid", "Wrong password");
        }

        var accessToken = _tokenManager.CreateToken(user);
        var refreshToken = _tokenManager.GenerateRefreshToken(user);

        await _userManager.UpdateAsync(user);

        return new AuthResponse
        {
            Username = user.UserName,
            Email = user.Email!,
            Token = accessToken,
            RefreshToken = refreshToken
        };
    }
}