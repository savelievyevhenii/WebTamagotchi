using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAll(CancellationToken cancellationToken);

    Task<Pet?> Get(string id, CancellationToken cancellationToken);

    Task Create(Pet pet, CancellationToken cancellationToken);

    Task Update(Pet pet, CancellationToken cancellationToken);
    
    Task Delete(Pet pet, CancellationToken cancellationToken);
}