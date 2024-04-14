using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class GetFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<GetFoodCommand, Result<Food, Error>>
{
    public async Task<Result<Food, Error>> Handle(GetFoodCommand request,
        CancellationToken cancellationToken)
    {
        var food = await foodRepository.Get(request.Id, cancellationToken);
        return food != null
            ? food
            : new FoodNotFoundError("food_not_found", $"Food not found with Id {request.Id}");
    }
}