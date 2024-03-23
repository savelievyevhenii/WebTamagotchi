using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IBathroomRepository
{
    Task<IEnumerable<Bathroom>> GetAll(CancellationToken cancellationToken);
    
    Task<Bathroom?> Get(string name, CancellationToken cancellationToken);

    Task Create(Bathroom bathroom);
}