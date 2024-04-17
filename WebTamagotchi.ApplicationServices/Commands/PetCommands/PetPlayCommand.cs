using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class PetPlayCommand: IRequest<Result<Pet, Error>>
{
    public string PetId { get; init; } = null!;
    
    public string GameId { get; init; } = null!;
}