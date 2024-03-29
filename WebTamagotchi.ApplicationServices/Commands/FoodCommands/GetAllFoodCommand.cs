using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.ApplicationServices.Commands.FoodCommands;

public class GetAllFoodCommand : IRequest<Result<IEnumerable<FoodDto>>>;