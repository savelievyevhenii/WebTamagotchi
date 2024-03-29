using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class GetFoodCommand : IRequest<Result<FoodDto, Error>>
{
    public string Name { get; init; } = null!;
}