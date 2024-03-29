using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class UpdateFoodCommand(FoodDto foodToUpdate) : IRequest<Result<FoodDto, Error>>
{
    public FoodDto FoodToUpdate { get; } = foodToUpdate;
}