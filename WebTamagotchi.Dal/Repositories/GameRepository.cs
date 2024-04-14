using Microsoft.EntityFrameworkCore;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Dal.Repositories;

public class GameRepository(WebTamagotchiDbContext dbContext) : IGameRepository
{
    public async Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Games.ToListAsync(cancellationToken);
    }

    public async Task<Game?> Get(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Games.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Create(Game game, CancellationToken cancellationToken)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Game game, CancellationToken cancellationToken)
    {
        dbContext.Games.Update(game);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Game game, CancellationToken cancellationToken)
    {
        dbContext.Games.Remove(game);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}