using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class GetBathroomCommand : IRequest<Result<Bathroom, Error>>
{
    public string Id { get; init; } = null!;
}