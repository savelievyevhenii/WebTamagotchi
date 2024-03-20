using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class DeleteUserCommand : IRequest<Maybe<Error>>
{
    public string Email { get; set; } = null!;
}