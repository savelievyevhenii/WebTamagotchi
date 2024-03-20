using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersByRoleHandler : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<User>, Error>>
{
    private readonly UserManager<User> _userManager;

    public GetUsersByRoleHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Result<IEnumerable<User>, Error>> Handle(GetUsersByRoleCommand request,
        CancellationToken cancellationToken)
    {
        return _userManager.Users.Where(u => u.Role == request.Role).ToList();
    }
}