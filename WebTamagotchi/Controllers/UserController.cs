using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
     private readonly IMediator _mediator;

     public UserController(IMediator mediator)
     {
          _mediator = mediator;
     }
     
     [HttpGet("users")]
     public async Task<IActionResult> GetUsersByRole(Role role, CancellationToken cancellationToken)
     {
         var command = new GetUsersByRoleCommand { Role = role };
         
         var response = await _mediator.Send(command, cancellationToken);

         return response.IsSuccess
             ? Ok(response.Value)
             : BadRequest($"Getting users failed: {response.Error}");
     }
//
//
//     [HttpGet("player")]
//     public async Task<IActionResult> GetPlayer(string email)
//     {
//         var result = await _userService.GetPlayer(email);
//         
//         return result.IsSuccess
//             ? Ok(result.Value)
//             : BadRequest($"Getting player failed: {result.Error}");
//     }
//
//     [HttpDelete("player")]
//     public async Task<IActionResult> DeletePlayer(string email)
//     {
//         var result = await _userService.DeletePlayer(email);
//
//         return result.IsSuccess
//             ? Ok($"Player '{email}' deleted")
//             : BadRequest($"Deleting player failed: {result.Error}");
//     }
//     
//     [HttpGet("admins")]
//     public async Task<IActionResult> GetAdmins()
//     {
//         var result = await _userService.GetAdmins();
//
//         return result.IsSuccess
//             ? Ok(result.Value)
//             : BadRequest($"Getting players failed: {result.Error}");
//     }
//     
//     [HttpGet("admin")]
//     public async Task<IActionResult> GetAdmin(string email)
//     {
//         var result = await _userService.GetAdmin(email);
//
//         return result.IsSuccess
//             ? Ok(result.Value)
//             : BadRequest($"Getting admin failed: {result.Error}");
//     }
//     
//     [HttpDelete("admin")]
//     public async Task<IActionResult> DeleteAdmin(string email)
//     {
//         var result = await _userService.DeleteAdmin(email);
//
//         return result.IsSuccess
//             ? Ok($"Admin '{email}' deleted")
//             : BadRequest($"Deleting player failed: {result.Error}");
//     }
//     
//     [HttpPost("change-role")]
//     public async Task<IActionResult> ChangeRole(string email, RoleDto roleDto)
//     {
//         var role = RoleConverter.ToModel(roleDto);
//         var result = await _userService.ChangeRole(email, role);
//
//         return result.IsSuccess
//             ? Ok(UserConverter.ToDto(result.Value))
//             : BadRequest($"Changing user role failed: {result.Error}");
//     }
}