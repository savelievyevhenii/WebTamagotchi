using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class GetUsersByRoleCommand : IRequest<Result<IEnumerable<UserDto>, Error>>
{
    public Role Role { get; init; }
}