using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class DeleteGameCommand : IRequest<Maybe<Error>>
{
    public string Name { get; init; } = null!;
}