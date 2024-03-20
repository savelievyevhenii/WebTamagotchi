using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RevokeAllCommand : IRequest<Maybe<Error>>
{
}