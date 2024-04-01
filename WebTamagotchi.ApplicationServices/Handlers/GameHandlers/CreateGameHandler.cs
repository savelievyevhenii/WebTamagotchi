using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class CreateGameHandler(IGameRepository gameRepository)
    : IRequestHandler<CreateGameCommand, Result<GameDto, Error>>
{
    public async Task<Result<GameDto, Error>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = GameConverter.ToModel(request.GameToCreate);
        game.Id = Guid.NewGuid().ToString();

        await gameRepository.Create(game, cancellationToken);

        return GameConverter.ToDto(game);
    }
}