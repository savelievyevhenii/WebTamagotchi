using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories.Interfaces;

public interface IBathroomRepository 
{
    Task<Bathroom?> Find(string name, CancellationToken cancellationToken);
}