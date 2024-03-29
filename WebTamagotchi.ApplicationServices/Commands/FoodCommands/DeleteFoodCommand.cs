using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class DeleteFoodCommand : IRequest<Maybe<Error>>
{
    public string Name { get; init; } = null!;
}