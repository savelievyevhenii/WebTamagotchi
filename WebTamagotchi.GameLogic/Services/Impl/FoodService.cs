using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services.Impl;

public class FoodService : IFoodService
{
    private readonly GameLogicDbContext _context;

    public FoodService(GameLogicDbContext context)
    {
        _context = context;
    }
    
    public async Task<Result<Food>> Get(string name)
    {
        try
        {
            var food = await _context.Foods.FirstOrDefaultAsync(f => f.Name.ToUpper().Equals(name.ToUpper()));
            return food != null
                ? Result.Success(food)
                : Result.Failure<Food>($"Food with name '{name}' not found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<Food>($"Failed to retrieve food. Error: {ex.Message}");
        }
    }

    public async Task<Result<List<Food>>> GetAll()
    {
        try
        {
            var foods = await _context.Foods.ToListAsync();
            return foods.Count != 0
                ? Result.Success(foods)
                : Result.Failure<List<Food>>("No foods found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Food>>($"Failed to retrieve foods. Error: {ex.Message}");
        }
    }

    public async Task<Result<Food>> Create(Food food)
    {
        try
        {
            food.Id = Guid.NewGuid().ToString();
            _context.Foods.Add(food);

            await _context.SaveChangesAsync();

            return Result.Success(food);
        }
        catch (Exception ex)
        {
            return Result.Failure<Food>($"Failed to create food. Error: {ex.Message}");
        }
    }

    public async Task<Result<Food>> Update(Food updatedFood, string id)
    {
        try
        {
            var existingFood = await _context.Foods.FindAsync(id);

            if (existingFood == null)
            {
                return Result.Failure<Food>($"Food with id '{id}' not found.");
            }

            existingFood.Name = updatedFood.Name;
            existingFood.Satiety = updatedFood.Satiety;
            existingFood.Dirtiness = updatedFood.Dirtiness;
            existingFood.Experience = updatedFood.Experience;

            await _context.SaveChangesAsync();

            return Result.Success(existingFood);
        }
        catch (Exception ex)
        {
            return Result.Failure<Food>($"Failed to update food. Error: {ex.Message}");
        }
    }

    public async Task<Result> Delete(string name)
    {
        try
        {
            var foodToDelete = await _context.Foods.FirstOrDefaultAsync(g => g.Name.ToUpper().Equals(name.ToUpper()));

            if (foodToDelete == null)
            {
                return Result.Failure($"Food with name '{name}' not found.");
            }

            _context.Foods.Remove(foodToDelete);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete food. Error: {ex.Message}");
        }
    }
}