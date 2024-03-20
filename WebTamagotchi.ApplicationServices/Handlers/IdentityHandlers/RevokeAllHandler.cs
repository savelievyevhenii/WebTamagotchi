using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RevokeAllHandler(UserManager<User> userManager) : IRequestHandler<RevokeAllCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(RevokeAllCommand request, CancellationToken cancellationToken)
    {
        var users = userManager.Users.ToList();

        foreach (var user in users)
        {
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
        }

        return Maybe<Error>.None;
    }
}