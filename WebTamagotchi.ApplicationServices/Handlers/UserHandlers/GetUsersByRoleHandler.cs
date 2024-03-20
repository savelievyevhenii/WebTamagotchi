using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersByRoleHandler(UserManager<User> userManager)
    : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<UserDto>, Error>>
{
    public Task<Result<IEnumerable<UserDto>, Error>> Handle(GetUsersByRoleCommand request,
        CancellationToken cancellationToken)
    {
        var users = userManager.Users.Where(u => u.Role == request.Role).ToList();
        var usersDtos = users.Select(UserConverter.ToDto).ToList();

        return Task.FromResult<Result<IEnumerable<UserDto>, Error>>(usersDtos);
    }
}