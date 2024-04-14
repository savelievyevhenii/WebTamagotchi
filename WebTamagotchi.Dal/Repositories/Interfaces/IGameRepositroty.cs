using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken);

    Task<Game?> Get(string id, CancellationToken cancellationToken);

    Task Create(Game game, CancellationToken cancellationToken);

    Task Update(Game game, CancellationToken cancellationToken);
    
    Task Delete(Game game, CancellationToken cancellationToken);
}