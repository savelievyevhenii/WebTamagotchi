using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomHandlers;

public class UpdateBedroomHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<UpdateBedroomCommand, Result<BedroomDto, Error>>
{
    public async Task<Result<BedroomDto, Error>> Handle(UpdateBedroomCommand request, CancellationToken cancellationToken)
    {
        var existingBedroom = await bedroomRepository.Get(request.BedroomToUpdate.Name, cancellationToken);

        if (existingBedroom == null)
        {
            return BedroomNotFoundError.BedroomNotFound;
        }

        existingBedroom.Energy = request.BedroomToUpdate.Energy;
        existingBedroom.Experience = request.BedroomToUpdate.Experience;

        await bedroomRepository.Update(existingBedroom, cancellationToken);

        return BedroomConverter.ToDto(existingBedroom);
    }
}