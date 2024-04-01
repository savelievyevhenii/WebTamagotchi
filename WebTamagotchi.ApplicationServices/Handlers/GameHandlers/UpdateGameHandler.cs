using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class UpdateGameHandler(IGameRepository gameRepository)
    : IRequestHandler<UpdateGameCommand, Result<GameDto, Error>>
{
    public async Task<Result<GameDto, Error>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var existingGame = await gameRepository.Get(request.GameToUpdate.Name, cancellationToken);

        if (existingGame == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        existingGame.Fun = request.GameToUpdate.Fun;
        existingGame.Hunger = request.GameToUpdate.Hunger;
        existingGame.Dirtiness = request.GameToUpdate.Dirtiness;
        existingGame.Tiredness = request.GameToUpdate.Tiredness;
        existingGame.Experience = request.GameToUpdate.Experience;

        await gameRepository.Update(existingGame, cancellationToken);

        return GameConverter.ToDto(existingGame);
    }
}