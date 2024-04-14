using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class GetBathroomsHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<GetBathroomsCommand, Result<IEnumerable<Bathroom>>>
{
    public async Task<Result<IEnumerable<Bathroom>>> Handle(GetBathroomsCommand request,
        CancellationToken cancellationToken)
    {
        var bathrooms = await bathroomRepository.GetAll(cancellationToken);
        
        return bathrooms.ToList();
    }
}