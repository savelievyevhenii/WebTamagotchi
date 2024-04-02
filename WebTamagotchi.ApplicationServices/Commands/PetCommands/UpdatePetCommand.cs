using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class UpdatePetCommand(PetDto petToUpdate) : IRequest<Result<PetDto, Error>>
{
    public PetDto PetToUpdate { get; } = petToUpdate;
}