using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class DeleteBathroomHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<DeleteBathroomCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeleteBathroomCommand request, CancellationToken cancellationToken)
    {
        var bathroomToDelete = await bathroomRepository.Get(request.Name, cancellationToken);

        if (bathroomToDelete == null)
        {
            return BathroomNotFoundError.BathroomNotFound;
        }

        await bathroomRepository.Delete(bathroomToDelete, cancellationToken);

        return Maybe.None;
    }
}