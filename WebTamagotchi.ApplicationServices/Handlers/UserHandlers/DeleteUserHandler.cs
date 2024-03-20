using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class DeleteUserHandler(UserManager<User> userManager) : IRequestHandler<DeleteUserCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserNotFoundError("user_not_found", $"User not found with email {request.Email}");
        }

        await userManager.DeleteAsync(user);

        return Maybe<Error>.None;
    }
}