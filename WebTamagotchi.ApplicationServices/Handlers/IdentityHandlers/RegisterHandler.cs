using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RegisterHandler(UserManager<User> userManager)
    : IRequestHandler<RegisterCommand, Result<AuthRequestDto, Error>>
{
    public async Task<Result<AuthRequestDto, Error>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User { UserName = request.Email, Email = request.Email, Role = Role.Player };

        await userManager.CreateAsync(user, request.Password!);

        return new AuthRequestDto()
        {
            Email = request.Email,
            Password = request.Password
        };
    }
}