using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomHandlers;

public class CreateBedroomHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<CreateBedroomCommand, Result<BedroomDto, Error>>
{
    public async Task<Result<BedroomDto, Error>> Handle(CreateBedroomCommand request, CancellationToken cancellationToken)
    {
        var bedroom = BedroomConverter.ToModel(request.BedroomToCreate);
        bedroom.Id = Guid.NewGuid().ToString();

        await bedroomRepository.Create(bedroom, cancellationToken);

        return BedroomConverter.ToDto(bedroom);
    }
}