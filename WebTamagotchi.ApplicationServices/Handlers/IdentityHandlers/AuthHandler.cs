using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Infrastructure.TokenManager;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class AuthHandler : IRequestHandler<AuthCommand, Result<AuthResponse, Error>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly ITokenManager _tokenManager;

    public AuthHandler(IUserRepository userRepository, UserManager<User> userManager, ITokenManager tokenManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _tokenManager = tokenManager;
    }

    public async Task<Result<AuthResponse, Error>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        if (managedUser == null)
        {
            return new UserValidationError("email_not_valid", $"Invalid user email: {request.Email}");
        }

        if (!await _userManager.CheckPasswordAsync(managedUser, request.Password!))
        {
            return new UserValidationError("password_not_valid", "Wrong password");
        }

        var foundUser = await _userRepository.Find(request.Email, cancellationToken);

        var accessToken = _tokenManager.CreateToken(foundUser);
        var refreshToken = _tokenManager.GenerateRefreshToken(foundUser);

        await _userRepository.Update(foundUser, cancellationToken);

        return new AuthResponse
        {
            Username = foundUser.UserName,
            Email = foundUser.Email!,
            Token = accessToken,
            RefreshToken = refreshToken
        };
    }
}