using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersByRoleHandler : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<User>, Error>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByRoleHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IEnumerable<User>, Error>> Handle(GetUsersByRoleCommand request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsers(cancellationToken);

        var filteredUsers = users.Where(u => u.Role == request.Role).ToList();
        
        if (filteredUsers.Count == 0)
        {
            return new UserNotFoundError("users_not_found", $"Users not found with role {request.Role}");
        }
        
        return filteredUsers;
    }
}