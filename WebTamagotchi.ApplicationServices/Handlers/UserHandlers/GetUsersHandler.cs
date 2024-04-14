using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersHandler(UserManager<User> userManager)
    : IRequestHandler<GetUsersCommand, Result<IEnumerable<User>, Error>>
{
    public Task<Result<IEnumerable<User>, Error>> Handle(GetUsersCommand request,
        CancellationToken cancellationToken)
    {
        var users = userManager.Users.ToList();

        return Task.FromResult<Result<IEnumerable<User>, Error>>(users);
    }
}