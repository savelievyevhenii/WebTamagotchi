using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RegisterHandler : IRequestHandler<RegisterCommand, Result<AuthRequest, Error>>
{
    private readonly UserManager<User> _userManager;

    public RegisterHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<AuthRequest, Error>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User { UserName = request.Email, Email = request.Email, Role = Role.Player };

        await _userManager.CreateAsync(user, request.Password!);

        return new AuthRequest
        {
            Email = request.Email,
            Password = request.Password
        };
    }
}