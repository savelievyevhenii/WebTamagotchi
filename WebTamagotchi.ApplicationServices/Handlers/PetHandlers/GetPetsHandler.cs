using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class GetPetsHandler(IPetRepository petRepository)
    : IRequestHandler<GetPetsCommand, Result<IEnumerable<Pet>>>
{
    public async Task<Result<IEnumerable<Pet>>> Handle(GetPetsCommand request,
        CancellationToken cancellationToken)
    {
        var pets = await petRepository.GetAll(cancellationToken);
        
        return pets.ToList();
    }
}