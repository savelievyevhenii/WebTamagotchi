using CSharpFunctionalExtensions;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services;

public interface IGameService
{
    Task<Result<Game>> Get(string name);

    Task<Result<List<Game>>> GetAll();
    
    Task<Result<Game>> Create(Game game);

    Task<Result<Game>> Update(Game game, string id);
}