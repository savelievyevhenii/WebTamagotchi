using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomsHandlers;

public class GetBedroomHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<GetBedroomCommand, Result<BedroomDto, Error>>
{
    public async Task<Result<BedroomDto, Error>> Handle(GetBedroomCommand request,
        CancellationToken cancellationToken)
    {
        var bedroom = await bedroomRepository.Get(request.Name, cancellationToken);
        return bedroom != null
            ? BedroomConverter.ToDto(bedroom)
            : new BedroomNotFoundError("bedroom_not_found", $"Bedroom not found with name {request.Name}");
    }
}