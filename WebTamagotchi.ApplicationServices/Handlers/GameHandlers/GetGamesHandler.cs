using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class GetGamesHandler(IGameRepository gameRepository)
    : IRequestHandler<GetGamesCommand, Result<IEnumerable<Game>>>
{
    public async Task<Result<IEnumerable<Game>>> Handle(GetGamesCommand request,
        CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetAll(cancellationToken);
        
        return games.ToList();
    }
}