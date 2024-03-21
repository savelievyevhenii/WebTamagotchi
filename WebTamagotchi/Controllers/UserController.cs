using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.UserCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetUsersByRole(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var command = new GetUsersByRoleCommand { Role = RoleConverter.ToModel(roleDto) };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest($"Getting users failed: {response.Error.Message}");
    }

    [HttpGet]
    public async Task<IActionResult> GetUser(string email, CancellationToken cancellationToken)
    {
        var command = new GetUserCommand { Email = email };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest($"Getting player failed: {response.Error.Message}");
    }

    [HttpDelete("player")]
    public async Task<IActionResult> DeleteUser(string email, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand { Email = email };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"Revoke failed: {response.Value.Message}")
            : Ok($"Player '{email}' deleted");
    }

    [HttpPost("change-role")]
    public async Task<IActionResult> ChangeRole(string email, RoleDto roleDto, CancellationToken cancellationToken)
    {
        var command = new ChangeRoleCommand { Email = email, Role = RoleConverter.ToModel(roleDto) };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest($"Changing user role failed: {response.Error.Message}");
    }
}