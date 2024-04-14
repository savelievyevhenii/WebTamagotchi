using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class GetGameHandler(IGameRepository gameRepository)
    : IRequestHandler<GetGameCommand, Result<Game, Error>>
{
    public async Task<Result<Game, Error>> Handle(GetGameCommand request,
        CancellationToken cancellationToken)
    {
        var game = await gameRepository.Get(request.Id, cancellationToken);
        return game != null
            ? game
            : new GameNotFoundError("game_not_found", $"Game not found with Id {request.Id}");
    }
}