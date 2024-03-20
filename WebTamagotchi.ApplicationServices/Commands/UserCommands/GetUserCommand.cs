using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class GetUserCommand : IRequest<Result<User, Error>>
{
    public string Email { get; init; } = null!;
}