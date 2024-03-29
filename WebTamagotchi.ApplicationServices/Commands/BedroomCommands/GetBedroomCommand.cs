using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class GetBedroomCommand : IRequest<Result<BedroomDto, Error>>
{
    public string Name { get; init; } = null!;
}