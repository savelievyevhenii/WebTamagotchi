using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class GetPetsHandler(IPetRepository petRepository)
    : IRequestHandler<GetPetsCommand, Result<IEnumerable<PetDto>>>
{
    public async Task<Result<IEnumerable<PetDto>>> Handle(GetPetsCommand request,
        CancellationToken cancellationToken)
    {
        var pets = await petRepository.GetAll(cancellationToken);
        
        return pets.Select(PetConverter.ToDto).ToList();
    }
}