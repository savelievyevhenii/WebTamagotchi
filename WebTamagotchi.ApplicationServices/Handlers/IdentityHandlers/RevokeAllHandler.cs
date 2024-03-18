using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RevokeAllHandler : IRequestHandler<RevokeAllCommand, Maybe<Error>>
{
    private readonly UserManager<User> _userManager;

    public RevokeAllHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    public async Task<Maybe<Error>> Handle(RevokeAllCommand request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.ToList();

        foreach (var user in users)
        { 
            user.RefreshToken = null;
            _userManager.UpdateAsync(user).GetAwaiter().GetResult();
        }

        return Maybe<Error>.None;
    }
}