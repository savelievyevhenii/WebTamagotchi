using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class BathroomRepository(WebTamagotchiDbContext dbContext) : IBathroomRepository
{
    public async Task<IEnumerable<Bathroom>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Bathrooms.ToListAsync(cancellationToken);
    }

    public async Task<Bathroom?> Get(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Bathrooms.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Create(Bathroom bathroom, CancellationToken cancellationToken)
    {
        dbContext.Bathrooms.Add(bathroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Bathroom bathroom, CancellationToken cancellationToken)
    {
        dbContext.Bathrooms.Update(bathroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Bathroom bathroom, CancellationToken cancellationToken)
    {
        dbContext.Bathrooms.Remove(bathroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}