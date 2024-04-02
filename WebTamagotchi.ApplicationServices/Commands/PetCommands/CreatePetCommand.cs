using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class CreatePetCommand(PetDto petToCreate) : IRequest<Result<PetDto, Error>>
{
    public PetDto PetToCreate { get; } = petToCreate;
}