using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class PetWashHandler(IPetRepository petRepository, IBathroomRepository bathroomRepository)
    : IRequestHandler<PetWashCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(PetWashCommand request, CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.PetId, cancellationToken);
        var bathroom = await bathroomRepository.Get(request.BathroomId, cancellationToken);
        if (pet == null)
        {
            return PetNotFoundError.PetNotFound;
        }

        if (bathroom == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        pet.ExpToLevelUp = Math.Max(0, pet.ExpToLevelUp - bathroom.Experience);
        pet.Dirtiness = Math.Max(0, pet.Dirtiness - bathroom.Cleanliness);
        pet.Bore = Math.Min(100, pet.Bore + 20); // in db later

        await petRepository.Update(pet, cancellationToken);

        return pet;
    }
}