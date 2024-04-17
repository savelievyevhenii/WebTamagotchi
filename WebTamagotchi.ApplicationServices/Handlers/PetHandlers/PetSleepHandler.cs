using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class PetSleepHandler(IPetRepository petRepository, IBedroomRepository bedroomRepository)
    : IRequestHandler<PetSleepCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(PetSleepCommand request, CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.PetId, cancellationToken);
        var bedroom = await bedroomRepository.Get(request.BedroomId, cancellationToken);
        if (pet == null)
        {
            return PetNotFoundError.PetNotFound;
        }
        if (bedroom == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        pet.ExpToLevelUp -= bedroom.Experience;
        pet.Tiredness -= bedroom.Energy;

        await petRepository.Update(pet, cancellationToken);
        
        return pet;
    }
}