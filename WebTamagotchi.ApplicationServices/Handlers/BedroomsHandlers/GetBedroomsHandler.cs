using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomsHandlers;

public class GetBedroomsHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<GetBedroomsCommand, Result<IEnumerable<BedroomDto>>>
{
    public async Task<Result<IEnumerable<BedroomDto>>> Handle(GetBedroomsCommand request,
        CancellationToken cancellationToken)
    {
        var bedrooms = await bedroomRepository.GetAll(cancellationToken);
        
        return bedrooms.Select(BedroomConverter.ToDto).ToList();
    }
}