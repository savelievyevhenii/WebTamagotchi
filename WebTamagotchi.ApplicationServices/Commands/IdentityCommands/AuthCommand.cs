using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class AuthCommand : IRequest<Result<AuthResponseDto, Error>>
{
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;
}