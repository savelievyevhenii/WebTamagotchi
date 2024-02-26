using CSharpFunctionalExtensions;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services;

public interface IFoodService
{
    Task<Result<Food>> Get(string name);

    Task<Result<List<Food>>> GetAll();
    
    Task<Result<Food>> Create(Food food);

    Task<Result<Food>> Update(Food food, string id);
    
    Task<Result> Delete(string name);
}