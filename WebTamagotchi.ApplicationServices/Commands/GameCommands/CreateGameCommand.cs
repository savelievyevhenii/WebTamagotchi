using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class CreateGameCommand(GameDto gameToCreate) : IRequest<Result<GameDto, Error>>
{
    public GameDto GameToCreate { get; } = gameToCreate;
}