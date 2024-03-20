using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RevokeHandler(UserManager<User> userManager) : IRequestHandler<RevokeCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(RevokeCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return UserValidationError.UserNotFound;
        }

        user.RefreshToken = null;
        userManager.UpdateAsync(user).GetAwaiter().GetResult();

        return Maybe<Error>.None;
    }
}