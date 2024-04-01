using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.GameHandlers;

public class DeleteGameHandler(IGameRepository gameRepository)
    : IRequestHandler<DeleteGameCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var gameToDelete = await gameRepository.Get(request.Name, cancellationToken);

        if (gameToDelete == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        await gameRepository.Delete(gameToDelete, cancellationToken);

        return Maybe.None;
    }
}