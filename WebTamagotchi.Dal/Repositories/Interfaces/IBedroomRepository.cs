using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IBedroomRepository
{
    Task<IEnumerable<Bedroom>> GetAll(CancellationToken cancellationToken);

    Task<Bedroom?> Get(string name, CancellationToken cancellationToken);

    Task Create(Bedroom bedroom, CancellationToken cancellationToken);

    Task Update(Bedroom bedroom, CancellationToken cancellationToken);
    
    Task Delete(Bedroom bedroom, CancellationToken cancellationToken);
}