using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class DeletePetHandler(IPetRepository petRepository)
    : IRequestHandler<DeletePetCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var petToDelete = await petRepository.Get(request.Name, cancellationToken);

        if (petToDelete == null)
        {
            return PetNotFoundError.PetNotFound;
        }

        await petRepository.Delete(petToDelete, cancellationToken);

        return Maybe.None;
    }
}