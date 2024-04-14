using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomsHandlers;

public class GetBedroomHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<GetBedroomCommand, Result<Bedroom, Error>>
{
    public async Task<Result<Bedroom, Error>> Handle(GetBedroomCommand request,
        CancellationToken cancellationToken)
    {
        var bedroom = await bedroomRepository.Get(request.Id, cancellationToken);
        return bedroom != null
            ? bedroom
            : new BedroomNotFoundError("bedroom_not_found", $"Bedroom not found with Id {request.Id}");
    }
}