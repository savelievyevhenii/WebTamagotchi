using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class GetAllFoodCommand : IRequest<Result<IEnumerable<Food>>>;