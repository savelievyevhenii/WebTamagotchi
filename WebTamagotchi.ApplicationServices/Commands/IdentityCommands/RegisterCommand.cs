using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RegisterCommand : IRequest<Result<AuthRequest, Error>>
{
    public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;

    public string PasswordConfirm { get; set; } = null!;
}