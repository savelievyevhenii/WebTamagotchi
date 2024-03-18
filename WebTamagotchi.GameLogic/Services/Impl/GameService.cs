// using CSharpFunctionalExtensions;
// using Microsoft.EntityFrameworkCore;
// using WebTamagotchi.GameLogic.Models;
//
// namespace WebTamagotchi.GameLogic.Services.Impl;
//
// public class GameService : IGameService
// {
//     private readonly GameLogicDbContext _context;
//
//     public GameService(GameLogicDbContext context)
//     {
//         _context = context;
//     }
//
//     public async Task<Result<Game>> Get(string name)
//     {
//         try
//         {
//             var game = await _context.Games.FirstOrDefaultAsync(g => g.Name.ToUpper().Equals(name.ToUpper()));
//             return game != null
//                 ? Result.Success(game)
//                 : Result.Failure<Game>($"Game with name '{name}' not found.");
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Game>($"Failed to retrieve game. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<List<Game>>> GetAll()
//     {
//         try
//         {
//             var games = await _context.Games.ToListAsync();
//             return games.Count != 0
//                 ? Result.Success(games)
//                 : Result.Failure<List<Game>>("No games found.");
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<List<Game>>($"Failed to retrieve games. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<Game>> Create(Game game)
//     {
//         try
//         {
//             game.Id = Guid.NewGuid().ToString();
//             _context.Games.Add(game);
//
//             await _context.SaveChangesAsync();
//
//             return Result.Success(game);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Game>($"Failed to create game. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<Game>> Update(Game updatedGame, string id)
//     {
//         try
//         {
//             var existingGame = await _context.Games.FindAsync(id);
//
//             if (existingGame == null)
//             {
//                 return Result.Failure<Game>($"Game with id '{id}' not found.");
//             }
//
//             existingGame.Name = updatedGame.Name;
//             existingGame.Fun = updatedGame.Fun;
//             existingGame.Hunger = updatedGame.Hunger;
//             existingGame.Dirtiness = updatedGame.Dirtiness;
//             existingGame.Tiredness = updatedGame.Tiredness;
//             existingGame.Experience = updatedGame.Experience;
//
//             await _context.SaveChangesAsync();
//
//             return Result.Success(existingGame);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Game>($"Failed to update game. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result> Delete(string name)
//     {
//         try
//         {
//             var gameToDelete = await _context.Games.FirstOrDefaultAsync(g => g.Name.ToUpper().Equals(name.ToUpper()));
//
//             if (gameToDelete == null)
//             {
//                 return Result.Failure($"Game with name '{name}' not found.");
//             }
//
//             _context.Games.Remove(gameToDelete);
//             await _context.SaveChangesAsync();
//
//             return Result.Success();
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure($"Failed to delete game. Error: {ex.Message}");
//         }
//     }
// }