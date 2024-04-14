using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class GetBedroomCommand : IRequest<Result<Bedroom, Error>>
{
    public string Id { get; init; } = null!;
}