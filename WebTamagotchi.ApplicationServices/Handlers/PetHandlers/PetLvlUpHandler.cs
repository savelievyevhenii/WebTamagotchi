using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class PetLvlUpHandler(IPetRepository petRepository) : IRequestHandler<PetLvlUpCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(PetLvlUpCommand request, CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.PetId, cancellationToken);
        if (pet == null)
        {
            return PetNotFoundError.PetNotFound;
        }

        pet.ExpToLevelUp = 100;
        pet.Level++;

        await petRepository.Update(pet, cancellationToken);

        return pet;
    }
}