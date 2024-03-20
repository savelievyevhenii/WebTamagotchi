using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RevokeCommand : IRequest<Maybe<Error>>
{
    public string Username { get; set; } = null!;
}