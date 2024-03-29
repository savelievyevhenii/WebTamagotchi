using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BedroomHandlers;

public class DeleteBedroomHandler(IBedroomRepository bedroomRepository)
    : IRequestHandler<DeleteBedroomCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeleteBedroomCommand request, CancellationToken cancellationToken)
    {
        var bedroomToDelete = await bedroomRepository.Get(request.Name, cancellationToken);

        if (bedroomToDelete == null)
        {
            return BedroomNotFoundError.BedroomNotFound;
        }

        await bedroomRepository.Delete(bedroomToDelete, cancellationToken);

        return Maybe.None;
    }
}