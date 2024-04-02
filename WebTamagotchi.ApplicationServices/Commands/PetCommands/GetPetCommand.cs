using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class GetPetCommand : IRequest<Result<PetDto, Error>>
{
    public string Name { get; init; } = null!;
}