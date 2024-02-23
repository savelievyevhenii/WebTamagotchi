using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services.Impl;

public class GameService : IGameService
{
    private readonly GameLogicDbContext _context;

    public GameService(GameLogicDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Game>> Get(string name)
    {
        try
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == name.ToUpper());
            return game != null
                ? Result.Success(game)
                : Result.Failure<Game>($"Game with name '{name}' not found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<Game>($"Failed to retrieve game. Error: {ex.Message}");
        }
    }

    public async Task<Result<List<Game>>> GetAll()
    {
        try
        {
            var games = await _context.Games.ToListAsync();
            return games.Count != 0
                ? Result.Success(games)
                : Result.Failure<List<Game>>("No games found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Game>>($"Failed to retrieve games. Error: {ex.Message}");
        }
    }

    public async Task<Result<Game>> Create(Game game)
    {
        try
        {
            game.Id = Guid.NewGuid().ToString();
            game.Name = game.Name.ToUpper();
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