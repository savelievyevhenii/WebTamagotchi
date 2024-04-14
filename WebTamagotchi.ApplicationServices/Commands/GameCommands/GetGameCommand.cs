using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class GetGameCommand : IRequest<Result<Game, Error>>
{
    public string Id { get; init; } = null!;
}