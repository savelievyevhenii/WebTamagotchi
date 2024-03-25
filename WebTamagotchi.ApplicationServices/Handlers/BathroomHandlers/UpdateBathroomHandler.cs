using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class UpdateBathroomHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<UpdateBathroomCommand, Result<BathroomDto, Error>>
{
    public async Task<Result<BathroomDto, Error>> Handle(UpdateBathroomCommand request, CancellationToken cancellationToken)
    {
        var existingBathroom = await bathroomRepository.Get(request.BathroomToUpdate.Name, cancellationToken);

        if (existingBathroom == null)
        {
            return BathroomNotFoundError.BathroomNotFound;
        }

        existingBathroom.Cleanliness = request.BathroomToUpdate.Cleanliness;
        existingBathroom.Experience = request.BathroomToUpdate.Experience;

        await bathroomRepository.Update(existingBathroom, cancellationToken);

        return BathroomConverter.ToDto(existingBathroom);
    }
}