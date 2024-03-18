using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Infrastructure.TokenManager;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<TokenModel, Error>>
{
    private readonly ITokenManager _tokenManager;
    private readonly UserManager<User> _userManager;

    public RefreshTokenHandler(ITokenManager tokenManager, UserManager<User> userManager)
    {
        _tokenManager = tokenManager;
        _userManager = userManager;
    }

    public async Task<Result<TokenModel, Error>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = _tokenManager.GetPrincipalFromExpiredToken(request.AccessToken);

        var user = await _userManager.FindByNameAsync(principal.Identity?.Name!);
        if (user == null)
        {
            return InvalidTokenError.InvalidToken;
        }
        
        if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return InvalidTokenError.InvalidToken;
        }

        var newAccessToken = _tokenManager.CreateToken(user);
        var newRefreshToken = _tokenManager.GenerateRefreshToken(user);

        user.RefreshToken = newRefreshToken;
        _userManager.UpdateAsync(user).GetAwaiter().GetResult();

        return new TokenModel
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}