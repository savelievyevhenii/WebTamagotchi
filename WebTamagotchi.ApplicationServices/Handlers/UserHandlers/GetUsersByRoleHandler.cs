using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersByRoleHandler(UserManager<User> userManager)
    : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<User>, Error>>
{
    public Task<Result<IEnumerable<User>, Error>> Handle(GetUsersByRoleCommand request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult<Result<IEnumerable<User>, Error>>(userManager.Users.Where(u => u.Role == request.Role)
            .ToList());
    }
}