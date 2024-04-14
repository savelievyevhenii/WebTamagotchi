using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetAll(CancellationToken cancellationToken);

    Task<Food?> Get(string id, CancellationToken cancellationToken);

    Task Create(Food food, CancellationToken cancellationToken);

    Task Update(Food food, CancellationToken cancellationToken);
    
    Task Delete(Food food, CancellationToken cancellationToken);
}