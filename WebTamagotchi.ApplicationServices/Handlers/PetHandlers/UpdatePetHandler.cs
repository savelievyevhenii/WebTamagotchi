using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class UpdatePetHandler(IPetRepository petRepository)
    : IRequestHandler<UpdatePetCommand, Result<PetDto, Error>>
{
    public async Task<Result<PetDto, Error>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var existingPet = await petRepository.Get(request.PetToUpdate.Name, cancellationToken);

        if (existingPet == null)
        {
            return PetNotFoundError.PetNotFound;
        }

        // todo
        
        await petRepository.Update(existingPet, cancellationToken);

        return PetConverter.ToDto(existingPet);
    }
}