using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class UpdateFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<UpdateFoodCommand, Result<FoodDto, Error>>
{
    public async Task<Result<FoodDto, Error>> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var existingFood = await foodRepository.Get(request.FoodToUpdate.Name, cancellationToken);

        if (existingFood == null)
        {
            return FoodNotFoundError.FoodNotFound;
        }

        existingFood.Satiety = request.FoodToUpdate.Satiety;
        existingFood.Experience = request.FoodToUpdate.Experience;

        await foodRepository.Update(existingFood, cancellationToken);

        return FoodConverter.ToDto(existingFood);
    }
}