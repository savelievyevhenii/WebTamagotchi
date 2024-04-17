using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class PetSleepCommand : IRequest<Result<Pet, Error>>
{
    public string PetId { get; init; } = null!;

    public string BedroomId { get; init; } = null!;
}