using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class GetPetCommand : IRequest<Result<Pet, Error>>
{
    public string Id { get; init; } = null!;
}