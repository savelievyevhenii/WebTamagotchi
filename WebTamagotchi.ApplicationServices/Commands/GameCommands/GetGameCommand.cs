using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class GetGameCommand : IRequest<Result<GameDto, Error>>
{
    public string Name { get; init; } = null!;
}