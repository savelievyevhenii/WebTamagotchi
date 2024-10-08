﻿using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Infrastructure.TokenManager;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class AuthHandler(UserManager<User> userManager, ITokenManager tokenManager)
    : IRequestHandler<AuthCommand, Result<AuthResponseDto, Error>>
{
    public async Task<Result<AuthResponseDto, Error>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserValidationError("email_not_valid", $"Invalid user email: {request.Email}");
        }

        if (!await userManager.CheckPasswordAsync(user, request.Password!))
        {
            return new UserValidationError("password_not_valid", "Wrong password");
        }

        var accessToken = tokenManager.CreateToken(user);
        var refreshToken = tokenManager.GenerateRefreshToken(user);

        await userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            Username = user.UserName, Email = user.Email!, Token = accessToken, RefreshToken = refreshToken
        };
    }
}