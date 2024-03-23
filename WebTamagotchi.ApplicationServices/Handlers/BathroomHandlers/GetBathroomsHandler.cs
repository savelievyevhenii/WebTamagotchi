using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class GetBathroomsHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<GetBathroomsCommand, Result<IEnumerable<BathroomDto>>>
{
    public async Task<Result<IEnumerable<BathroomDto>>> Handle(GetBathroomsCommand request,
        CancellationToken cancellationToken)
    {
        var bathrooms = await bathroomRepository.GetAll(cancellationToken);
        
        return bathrooms.Select(BathroomConverter.ToDto).ToList();
    }
}