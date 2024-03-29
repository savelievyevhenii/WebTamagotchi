using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class GetFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<GetFoodCommand, Result<FoodDto, Error>>
{
    public async Task<Result<FoodDto, Error>> Handle(GetFoodCommand request,
        CancellationToken cancellationToken)
    {
        var food = await foodRepository.Get(request.Name, cancellationToken);
        return food != null
            ? FoodConverter.ToDto(food)
            : new FoodNotFoundError("food_not_found", $"Food not found with name {request.Name}");
    }
}