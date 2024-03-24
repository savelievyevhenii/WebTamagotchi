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

    public async Task<Bathroom?> Get(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Bathrooms.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task Create(Bathroom bathroom)
    {
        dbContext.Bathrooms.Add(bathroom);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Bathroom bathroom)
    {
        dbContext.Bathrooms.Update(bathroom);
        await dbContext.SaveChangesAsync();
    }
}