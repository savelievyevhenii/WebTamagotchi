using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class GetFoodCommand : IRequest<Result<Food, Error>>
{
    public string Id { get; init; } = null!;
}