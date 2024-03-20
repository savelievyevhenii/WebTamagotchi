using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class GetUserCommand : IRequest<Result<UserDto, Error>>
{
    public string Email { get; init; } = null!;
}