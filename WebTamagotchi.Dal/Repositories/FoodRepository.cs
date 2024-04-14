using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class FoodRepository(WebTamagotchiDbContext dbContext) : IFoodRepository
{
    public async Task<IEnumerable<Food>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Foods.ToListAsync(cancellationToken);
    }

    public async Task<Food?> Get(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Foods.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Create(Food food, CancellationToken cancellationToken)
    {
        dbContext.Foods.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Food food, CancellationToken cancellationToken)
    {
        dbContext.Foods.Update(food);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Food food, CancellationToken cancellationToken)
    {
        dbContext.Foods.Remove(food);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}