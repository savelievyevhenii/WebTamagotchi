using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class GetUsersByRoleCommand : IRequest<Result<IEnumerable<User>, Error>>
{
    public Role Role { get; set; }
}