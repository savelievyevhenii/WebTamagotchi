using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class GetPetHandler(IPetRepository petRepository)
    : IRequestHandler<GetPetCommand, Result<PetDto, Error>>
{
    public async Task<Result<PetDto, Error>> Handle(GetPetCommand request,
        CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.Name, cancellationToken);
        return pet != null
            ? PetConverter.ToDto(pet)
            : new PetNotFoundError("pet_not_found", $"Pet not found with name {request.Name}");
    }
}