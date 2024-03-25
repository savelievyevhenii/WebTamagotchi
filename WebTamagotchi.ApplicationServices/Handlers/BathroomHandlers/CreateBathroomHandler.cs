using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class CreateBathroomHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<CreateBathroomCommand, Result<BathroomDto, Error>>
{
    public async Task<Result<BathroomDto, Error>> Handle(CreateBathroomCommand request, CancellationToken cancellationToken)
    {
        var bathroom = BathroomConverter.ToModel(request.BathroomToCreate);
        bathroom.Id = Guid.NewGuid().ToString();

        await bathroomRepository.Create(bathroom, cancellationToken);

        return BathroomConverter.ToDto(bathroom);
    }
}