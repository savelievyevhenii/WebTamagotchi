using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class CreatePetHandler(IPetRepository petRepository)
    : IRequestHandler<CreatePetCommand, Result<PetDto, Error>>
{
    public async Task<Result<PetDto, Error>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = PetConverter.ToModel(request.PetToCreate);
        pet.Id = Guid.NewGuid().ToString();

        await petRepository.Create(pet, cancellationToken);

        return PetConverter.ToDto(pet);
    }
}