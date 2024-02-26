using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.GameLogic.Services.Impl;

public class BathroomService : IBathroomService
{
    private readonly GameLogicDbContext _context;

    public BathroomService(GameLogicDbContext context)
    {
        _context = context;
    }


    public async Task<Result<Bathroom>> Get(string name)
    {
        try
        {
            var bathroom = await _context.Bathrooms.FirstOrDefaultAsync(b => b.Name.ToUpper().Equals(name.ToUpper()));
            return bathroom != null
                ? Result.Success(bathroom)
                : Result.Failure<Bathroom>($"Bathroom with name '{name}' not found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<Bathroom>($"Failed to retrieve bathroom. Error: {ex.Message}");
        }
    }

    public async Task<Result<List<Bathroom>>> GetAll()
    {
        try
        {
            var bathrooms = await _context.Bathrooms.ToListAsync();
            return bathrooms.Count != 0
                ? Result.Success(bathrooms)
                : Result.Failure<List<Bathroom>>("No bathrooms found.");
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Bathroom>>($"Failed to retrieve bathrooms. Error: {ex.Message}");
        }
    }

    public async Task<Result<Bathroom>> Create(Bathroom bathroom)
    {
        try
        {
            bathroom.Id = Guid.NewGuid().ToString();
            _context.Bathrooms.Add(bathroom);

            await _context.SaveChangesAsync();

            return Result.Success(bathroom);
        }
        catch (Exception ex)
        {
            return Result.Failure<Bathroom>($"Failed to create bathroom. Error: {ex.Message}");
        }
    }

    public async Task<Result<Bathroom>> Update(Bathroom updatedBathroom, string id)
    {
        try
        {
            var existingBathroom = await _context.Bathrooms.FindAsync(id);

            if (existingBathroom == null)
            {
                return Result.Failure<Bathroom>($"Bathroom with id '{id}' not found.");
            }

            existingBathroom.Name = updatedBathroom.Name;
            existingBathroom.Experience = updatedBathroom.Experience;
            existingBathroom.Cleanliness = updatedBathroom.Cleanliness;
            
            await _context.SaveChangesAsync();

            return Result.Success(existingBathroom);
        }
        catch (Exception ex)
        {
            return Result.Failure<Bathroom>($"Failed to update bathroom. Error: {ex.Message}");
        }
    }

    public async Task<Result> Delete(string name)
    {
        try
        {
            var bathroomToDelete = await _context.Bathrooms.FirstOrDefaultAsync(b => b.Name.ToUpper().Equals(name.ToUpper()));

            if (bathroomToDelete == null)
            {
                return Result.Failure($"Bathroom with name '{name}' not found.");
            }

            _context.Bathrooms.Remove(bathroomToDelete);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete bathroom. Error: {ex.Message}");
        }
    }
}