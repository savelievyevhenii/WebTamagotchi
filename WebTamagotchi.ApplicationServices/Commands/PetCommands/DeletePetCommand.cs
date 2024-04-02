using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class DeletePetCommand : IRequest<Maybe<Error>>
{
    public string Name { get; init; } = null!;
}