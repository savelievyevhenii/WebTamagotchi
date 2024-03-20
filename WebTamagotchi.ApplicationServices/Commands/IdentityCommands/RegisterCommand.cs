using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RegisterCommand : IRequest<Result<AuthRequestDto, Error>>
{
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;

    public string PasswordConfirm { get; set; } = null!;
}