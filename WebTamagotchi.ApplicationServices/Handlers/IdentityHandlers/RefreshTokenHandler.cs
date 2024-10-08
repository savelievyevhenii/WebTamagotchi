﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Infrastructure.TokenManager;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RefreshTokenHandler(ITokenManager tokenManager, UserManager<User> userManager)
    : IRequestHandler<RefreshTokenCommand, Result<TokenModelDto, Error>>
{
    public async Task<Result<TokenModelDto, Error>> Handle(RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var principal = tokenManager.GetPrincipalFromExpiredToken(request.AccessToken);

        var user = await userManager.FindByNameAsync(principal.Identity?.Name!);
        if (user == null)
        {
            return InvalidTokenError.InvalidToken;
        }

        if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return InvalidTokenError.InvalidToken;
        }

        var newAccessToken = tokenManager.CreateToken(user);
        var newRefreshToken = tokenManager.GenerateRefreshToken(user);

        user.RefreshToken = newRefreshToken;
        userManager.UpdateAsync(user).GetAwaiter().GetResult();

        return new TokenModelDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}