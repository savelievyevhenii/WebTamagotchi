using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class GetAllFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<GetAllFoodCommand, Result<IEnumerable<Food>>>
{
    public async Task<Result<IEnumerable<Food>>> Handle(GetAllFoodCommand request,
        CancellationToken cancellationToken)
    {
        var foods = await foodRepository.GetAll(cancellationToken);
        
        return foods.ToList();
    }
}