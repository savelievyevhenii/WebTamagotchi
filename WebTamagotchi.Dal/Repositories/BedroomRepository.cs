using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class BedroomRepository(WebTamagotchiDbContext dbContext) : IBedroomRepository
{
    public async Task<IEnumerable<Bedroom>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Bedrooms.ToListAsync(cancellationToken);
    }

    public async Task<Bedroom?> Get(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Bedrooms.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Create(Bedroom bedroom, CancellationToken cancellationToken)
    {
        dbContext.Bedrooms.Add(bedroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Bedroom bedroom, CancellationToken cancellationToken)
    {
        dbContext.Bedrooms.Update(bedroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Bedroom bedroom, CancellationToken cancellationToken)
    {
        dbContext.Bedrooms.Remove(bedroom);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}