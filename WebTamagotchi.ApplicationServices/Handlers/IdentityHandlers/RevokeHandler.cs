using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.IdentityHandlers;

public class RevokeHandler : IRequestHandler<RevokeCommand, Maybe<Error>>
{
    private readonly UserManager<User> _userManager;

    public RevokeHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Maybe<Error>> Handle(RevokeCommand request, CancellationToken cancellationToken)
    {

        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return UserValidationError.UserNotFound;
        }
        
        user.RefreshToken = null;
        _userManager.UpdateAsync(user).GetAwaiter().GetResult();

        return Maybe<Error>.None;
    }
}