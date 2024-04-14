using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomsHandlers;

public class GetBedroomsHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<GetBedroomsCommand, Result<IEnumerable<Bedroom>>>
{
    public async Task<Result<IEnumerable<Bedroom>>> Handle(GetBedroomsCommand request,
        CancellationToken cancellationToken)
    {
        var bedrooms = await bedroomRepository.GetAll(cancellationToken);
        
        return bedrooms.ToList();
    }
}