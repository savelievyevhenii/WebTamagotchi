// using CSharpFunctionalExtensions;
// using WebTamagotchi.GameLogic.Models;
// using WebTamagotchi.Identity.Services;
//
// namespace WebTamagotchi.GameLogic.Services.Impl;
//
// public class PetService : IPetService
// {
//     private readonly GameLogicDbContext _context;
//     private readonly IUserService _userService;
//
//     public PetService(GameLogicDbContext context, IUserService userService)
//     {
//         _context = context;
//         _userService = userService;
//     }
//
//     public async Task<Result<Pet>> Create(string petName, string userEmail)
//     {
//         try
//         {
//             var user = await _userService.GetPlayer(userEmail);
//
//             var pet = new Pet
//             {
//                 Id = Guid.NewGuid().ToString(),
//                 Name = petName,
//                 Level = 0,
//                 ExpToLevelUp = 100,
//                 Bore = 0, 
//                 Hunger = 0,
//                 Tiredness = 0,
//                 Dirtiness = 0,
//                 // Owner = user.Value
//             };
//
//             _context.Pets.Add(pet);
//
//             await _context.SaveChangesAsync();
//
//             return Result.Success(pet);
//         }
//         catch (Exception ex)
//         {
//             return Result.Failure<Pet>($"Failed to create pet. Error: {ex.Message}");
//         }
//     }
//
//     public Task Rename(Pet pet)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task Delete(Pet pet)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task Play(Pet pet, Game game)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task Feed(Pet pet, Food food)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task Bathe(Pet pet, Bathroom bathroom)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task Sleep(Pet pet, Bedroom bedroom)
//     {
//         throw new NotImplementedException();
//     }
// }