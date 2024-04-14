using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class GetBathroomHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<GetBathroomCommand, Result<Bathroom, Error>>
{
    public async Task<Result<Bathroom, Error>> Handle(GetBathroomCommand request,
        CancellationToken cancellationToken)
    {
        var bathroom = await bathroomRepository.Get(request.Id, cancellationToken);
        return bathroom != null
            ? bathroom
            : new BathroomNotFoundError("bathroom_not_found", $"Bathroom not found with Id {request.Id}");
    }
}