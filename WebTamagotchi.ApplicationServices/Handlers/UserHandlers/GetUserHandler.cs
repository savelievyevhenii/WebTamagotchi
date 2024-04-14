using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUserHandler(UserManager<User> userManager) : IRequestHandler<GetUserCommand, Result<User, Error>>
{
    public async Task<Result<User, Error>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);

        return user != null
            ? user
            : new UserNotFoundError("user_not_found", $"User not found with id {request.Id}");
    }
}