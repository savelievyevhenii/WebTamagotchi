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
             : BadRequest($"Getting users failed: {response.Error.Message}");
     }


     [HttpGet("user")]
     public async Task<IActionResult> GetUser(string email, CancellationToken cancellationToken)
     {
         var command = new GetUserCommand { Email = email };
         
         var response = await _mediator.Send(command, cancellationToken);
         
         return response.IsSuccess
             ? Ok(response.Value)
             : BadRequest($"Getting player failed: {response.Error.Message}");
     }

     [HttpDelete("player")]
     public async Task<IActionResult> DeleteUser(string email, CancellationToken cancellationToken)
     {
         var command = new DeleteUserCommand { Email = email };
         
         var response = await _mediator.Send(command, cancellationToken);

         return response.HasValue
             ? BadRequest($"Revoke failed: {response.Value.Message}")
             : Ok($"Player '{email}' deleted");
     }

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