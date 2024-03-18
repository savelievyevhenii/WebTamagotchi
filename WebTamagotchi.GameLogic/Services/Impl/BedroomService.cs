// using CSharpFunctionalExtensions;
// using Microsoft.EntityFrameworkCore;
// using WebTamagotchi.GameLogic.Models;
//
// namespace WebTamagotchi.GameLogic.Services.Impl;
//
// public class BedroomService : IBedroomService
// {
//     private readonly GameLogicDbContext _context;
//
//     public BedroomService(GameLogicDbContext context)
//     {
//         _context = context;
//     }
//     
//     public async Task<Result<Bedroom>> Get(string name)
//     {
//         try
//         {
//             var bedroom = await _context.Bedrooms.FirstOrDefaultAsync(b => b.Name.ToUpper().Equals(name.ToUpper()));
//             return bedroom != null
//                 ? Result.Success(bedroom)
//                 : Result.Failure<Bedroom>($"Bedroom with name '{name}' not found.");
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Bedroom>($"Failed to retrieve bedroom. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<List<Bedroom>>> GetAll()
//     {
//         try
//         {
//             var bedrooms = await _context.Bedrooms.ToListAsync();
//             return bedrooms.Count != 0
//                 ? Result.Success(bedrooms)
//                 : Result.Failure<List<Bedroom>>("No bedrooms found.");
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<List<Bedroom>>($"Failed to retrieve bedrooms. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<Bedroom>> Create(Bedroom bedroom)
//     {
//         try
//         {
//             bedroom.Id = Guid.NewGuid().ToString();
//             _context.Bedrooms.Add(bedroom);
//
//             await _context.SaveChangesAsync();
//
//             return Result.Success(bedroom);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Bedroom>($"Failed to create bedroom. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result<Bedroom>> Update(Bedroom updatedBedroom, string id)
//     {
//         try
//         {
//             var existingBedroom = await _context.Bedrooms.FindAsync(id);
//
//             if (existingBedroom == null)
//             {
//                 return Result.Failure<Bedroom>($"Bedroom with id '{id}' not found.");
//             }
//
//             existingBedroom.Name = updatedBedroom.Name;
//             existingBedroom.Experience = updatedBedroom.Experience;
//             existingBedroom.Energy = updatedBedroom.Energy;
//
//             await _context.SaveChangesAsync();
//
//             return Result.Success(existingBedroom);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Bedroom>($"Failed to update bedroom. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result> Delete(string name)
//     {
//         try
//         {
//             var bedroomToDelete = await _context.Bedrooms.FirstOrDefaultAsync(b => b.Name.ToUpper().Equals(name.ToUpper()));
//
//             if (bedroomToDelete == null)
//             {
//                 return Result.Failure($"Bedroom with name '{name}' not found.");
//             }
//
//             _context.Bedrooms.Remove(bedroomToDelete);
//             await _context.SaveChangesAsync();
//
//             return Result.Success();
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure($"Failed to delete bedroom. Error: {ex.Message}");
//         }
//     }
// }