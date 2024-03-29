using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class GetAllFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<GetAllFoodCommand, Result<IEnumerable<FoodDto>>>
{
    public async Task<Result<IEnumerable<FoodDto>>> Handle(GetAllFoodCommand request,
        CancellationToken cancellationToken)
    {
        var foods = await foodRepository.GetAll(cancellationToken);
        
        return foods.Select(FoodConverter.ToDto).ToList();
    }
}