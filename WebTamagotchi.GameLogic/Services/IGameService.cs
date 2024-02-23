using CSharpFunctionalExtensions;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services;

public interface IGameService
{
    Task<Result<Game>> Get();

    Task<Result<IEnumerable<Game>>> GetAll();
    
    Task<Result<Game>> Create(Game game);

    Task<Result<Game>> Update(Game game);
}