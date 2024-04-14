using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class PetRepository(WebTamagotchiDbContext dbContext) : IPetRepository
{
    public async Task<IEnumerable<Pet>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Pets.ToListAsync(cancellationToken);
    }

    public async Task<Pet?> Get(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Pets.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Create(Pet pet, CancellationToken cancellationToken)
    {
        dbContext.Pets.Add(pet);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Pet pet, CancellationToken cancellationToken)
    {
        dbContext.Pets.Update(pet);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Pet pet, CancellationToken cancellationToken)
    {
        dbContext.Pets.Remove(pet);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}