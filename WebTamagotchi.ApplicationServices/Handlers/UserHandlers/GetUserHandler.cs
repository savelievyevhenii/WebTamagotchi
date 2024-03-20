using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUserHandler(UserManager<User> userManager) : IRequestHandler<GetUserCommand, Result<UserDto, Error>>
{
    public async Task<Result<UserDto, Error>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        return user != null
            ? UserConverter.ToDto(user)
            : new UserNotFoundError("user_not_found", $"User not found with email {request.Email}");
    }
}