// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using WebTamagotchi.GameLogic.Services;
//
// namespace WebTamagotchi.Controllers;
//
// [Authorize]
// [ApiController]
// [Route("/api/[controller]")]
// public class PetController : ControllerBase
// {
//     private readonly IPetService _petService;
//
//     public PetController(IPetService petService)
//     {
//         _petService = petService;
//     }
//     
//     [HttpPost]
//     public async Task<IActionResult> CreateGame(string petName, string userEmail)
//     {
//         var result = await _petService.Create(petName, userEmail);
//
//         return result.IsSuccess
//             ? Ok(result.Value)
//             : BadRequest(result.Error);
//     }
// }