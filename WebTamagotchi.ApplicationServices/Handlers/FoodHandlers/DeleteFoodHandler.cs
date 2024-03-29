using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.FoodHandlers;

public class DeleteFoodHandler(IFoodRepository foodRepository)
    : IRequestHandler<DeleteFoodCommand, Maybe<Error>>
{
    public async Task<Maybe<Error>> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
        var foodToDelete = await foodRepository.Get(request.Name, cancellationToken);

        if (foodToDelete == null)
        {
            return FoodNotFoundError.FoodNotFound;
        }

        await foodRepository.Delete(foodToDelete, cancellationToken);

        return Maybe.None;
    }
}