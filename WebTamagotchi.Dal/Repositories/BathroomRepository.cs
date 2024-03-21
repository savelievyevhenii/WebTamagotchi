using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class BathroomRepository(WebTamagotchiDbContext dbContext) : IBathroomRepository
{
    public async Task<Bathroom?> Find(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Bathrooms.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
}