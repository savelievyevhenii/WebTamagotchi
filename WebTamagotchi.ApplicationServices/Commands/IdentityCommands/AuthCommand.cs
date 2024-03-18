using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class AuthCommand : IRequest<Result<AuthResponse, Error>>
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}