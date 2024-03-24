
//     public async Task<Result<Bathroom>> Update(Bathroom updatedBathroom, string id)
//     {
//         try
//         {
//             var existingBathroom = await _context.Bathrooms.FindAsync(id);
//
//             if (existingBathroom == null)
//             {
//                 return Result.Failure<Bathroom>($"Bathroom with id '{id}' not found.");
//             }
//
//             existingBathroom.Name = updatedBathroom.Name;
//             existingBathroom.Experience = updatedBathroom.Experience;
//             existingBathroom.Cleanliness = updatedBathroom.Cleanliness;
//             
//             await _context.SaveChangesAsync();
//
//             return Result.Success(existingBathroom);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Bathroom>($"Failed to update bathroom. Error: {ex.Message}");
//         }
//     }
//
//     public async Task<Result> Delete(string name)
//     {
//         try
//         {
//             var bathroomToDelete = await _context.Bathrooms.FirstOrDefaultAsync(b => b.Name.ToUpper().Equals(name.ToUpper()));
//
//             if (bathroomToDelete == null)
//             {
//                 return Result.Failure($"Bathroom with name '{name}' not found.");
//             }
//
//             _context.Bathrooms.Remove(bathroomToDelete);
//             await _context.SaveChangesAsync();
//
//             return Result.Success();
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure($"Failed to delete bathroom. Error: {ex.Message}");
//         }
//     }
// }