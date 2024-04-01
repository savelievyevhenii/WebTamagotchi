using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class GetGamesHandler(IGameRepository gameRepository)
    : IRequestHandler<GetGamesCommand, Result<IEnumerable<GameDto>>>
{
    public async Task<Result<IEnumerable<GameDto>>> Handle(GetGamesCommand request,
        CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetAll(cancellationToken);
        
        return games.Select(GameConverter.ToDto).ToList();
    }
}