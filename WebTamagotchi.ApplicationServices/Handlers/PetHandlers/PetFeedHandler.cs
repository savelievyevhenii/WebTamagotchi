using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class PetFeedHandler(IPetRepository petRepository, IFoodRepository foodRepository)
    : IRequestHandler<PetFeedCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(PetFeedCommand request, CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.PetId, cancellationToken);
        var food = await foodRepository.Get(request.FoodId, cancellationToken);
        if (pet == null)
        {
            return PetNotFoundError.PetNotFound;
        }
        if (food == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        pet.ExpToLevelUp -= food.Experience;
        pet.Hunger -= food.Satiety;
        pet.Dirtiness += food.Dirtiness;

        await petRepository.Update(pet, cancellationToken);
        
        return pet;
    }
}