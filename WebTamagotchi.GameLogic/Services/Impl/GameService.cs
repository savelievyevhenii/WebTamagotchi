using CSharpFunctionalExtensions;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services.Impl;

public class GameService : IGameService
{
    private readonly GameLogicDbContext _context;

    public GameService(GameLogicDbContext context)
    {
        _context = context;
    }
    
    public Task<Result<Game>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<Game>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Game>> Create(Game game)
    {
        try
        {
            game.Id = Guid.NewGuid().ToString();
            _context.Games.Add(game);
            
            await _context.SaveChangesAsync();
            
            return Result.Success(game);
        }
        catch (Exception ex)
        {
            return Result.Failure<Game>($"Failed to create game. Error: {ex.Message}");
        }
    }


    public Task<Result<Game>> Update(Game game)
    {
        throw new NotImplementedException();
    }
}