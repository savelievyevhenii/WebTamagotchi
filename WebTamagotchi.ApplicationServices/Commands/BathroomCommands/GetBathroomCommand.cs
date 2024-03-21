using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class GetBathroomCommand : IRequest<Result<BathroomDto, Error>>
{
    public string Name { get; init; } = null!;
}