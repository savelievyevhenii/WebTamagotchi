using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class CreateFoodCommand(FoodDto foodToCreate) : IRequest<Result<FoodDto, Error>>
{
    public FoodDto FoodToCreate { get; } = foodToCreate;
}