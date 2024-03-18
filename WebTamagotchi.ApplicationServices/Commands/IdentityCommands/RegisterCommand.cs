using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RegisterCommand : IRequest<Result<AuthRequest, Error>>
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordConfirm { get; set; } = null!;
}