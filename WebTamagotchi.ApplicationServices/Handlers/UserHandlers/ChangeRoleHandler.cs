using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class ChangeRoleHandler(UserManager<User> userManager) : IRequestHandler<ChangeRoleCommand, Result<UserDto, Error>>
{
    public async Task<Result<UserDto, Error>> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserNotFoundError("user_not_found", $"User not found with email {request.Email}");
        }

        user.Role = request.Role;

        await userManager.UpdateAsync(user);

        return UserConverter.ToDto(user);
    }
}