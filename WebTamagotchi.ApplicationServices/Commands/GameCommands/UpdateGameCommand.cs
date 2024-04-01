using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class UpdateGameCommand(GameDto gameToUpdate) : IRequest<Result<GameDto, Error>>
{
    public GameDto GameToUpdate { get; } = gameToUpdate;
}