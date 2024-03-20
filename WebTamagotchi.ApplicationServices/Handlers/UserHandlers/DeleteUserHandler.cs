using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Maybe<Error>>
{
    private readonly UserManager<User> _userManager;

    public DeleteUserHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Maybe<Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserNotFoundError("user_not_found", $"User not found with email {request.Email}");
        }

        await _userManager.DeleteAsync(user);

        return Maybe<Error>.None;
    }
}