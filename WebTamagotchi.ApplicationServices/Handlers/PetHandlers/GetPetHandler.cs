using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class GetPetHandler(IPetRepository petRepository)
    : IRequestHandler<GetPetCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(GetPetCommand request,
        CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.Id, cancellationToken);
        return pet != null
            ? pet
            : new PetNotFoundError("pet_not_found", $"Pet not found with Id {request.Id}");
    }
}