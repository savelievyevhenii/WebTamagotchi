using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class GetGameHandler(IGameRepository gameRepository)
    : IRequestHandler<GetGameCommand, Result<GameDto, Error>>
{
    public async Task<Result<GameDto, Error>> Handle(GetGameCommand request,
        CancellationToken cancellationToken)
    {
        var game = await gameRepository.Get(request.Name, cancellationToken);
        return game != null
            ? GameConverter.ToDto(game)
            : new GameNotFoundError("game_not_found", $"Game not found with name {request.Name}");
    }
}