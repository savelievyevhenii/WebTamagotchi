using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.UserHandlers;

public class GetUsersByRoleHandler : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<User>>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByRoleHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IEnumerable<User>>> Handle(GetUsersByRoleCommand request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersByRole(request.Role, cancellationToken);

        return users.ToList();
    }
}