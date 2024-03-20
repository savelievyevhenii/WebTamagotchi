using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class ChangeRoleHandler : IRequestHandler<ChangeRoleCommand, Result<User, Error>>
{
    private readonly UserManager<User> _userManager;

    public ChangeRoleHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<User, Error>> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new UserNotFoundError("user_not_found", $"User not found with email {request.Email}");
        }

        user.Role = request.Role;

        await _userManager.UpdateAsync(user);
        
        return user;
    }
}