using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class ChangeRoleCommand : IRequest<Result<User, Error>>
{
    public string Email { get; init; } = null!;

    public Role Role { get; init; }
}