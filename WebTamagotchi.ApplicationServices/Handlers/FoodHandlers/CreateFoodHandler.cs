using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class CreateFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<CreateFoodCommand, Result<FoodDto, Error>>
{
    public async Task<Result<FoodDto, Error>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var food = FoodConverter.ToModel(request.FoodToCreate);
        food.Id = Guid.NewGuid().ToString();

        await foodRepository.Create(food, cancellationToken);

        return FoodConverter.ToDto(food);
    }
}