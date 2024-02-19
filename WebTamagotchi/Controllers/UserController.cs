using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Services;

namespace WebTamagotchi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("players")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetPlayers()
    {
        try
        {
            var users = await _userService.GetPlayers();
            var userDtos = users.Select(UserConverter.ToDto).ToList();

            return Ok(userDtos);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting players failed: {e.Message}");
        }
    }

    [HttpGet("player")]
    public async Task<ActionResult<UserDto>> GetPlayer(string email)
    {
        try
        {
            var user = await _userService.GetPlayer(email);
            var userDto = UserConverter.ToDto(user);

            return Ok(userDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting player failed: {e.Message}");
        }
    }

    [HttpDelete("player")]
    public async Task<ActionResult> DeletePlayer(string email)
    {
        try
        {
            await _userService.DeletePlayer(email);

            return Ok($"User '{email}' deleted");
        }
        catch (Exception e)
        {
            return BadRequest($"Deleting player failed: {e.Message}");
        }
    }

    [HttpGet("admins")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAdmins()
    {
        try
        {
            var users = await _userService.GetAdmins();
            var userDtos = users.Select(UserConverter.ToDto).ToList();

            return Ok(userDtos);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting admins failed: {e.Message}");
        }
    }

    [HttpGet("admin")]
    public async Task<ActionResult<UserDto>> GetAdmin(string email)
    {
        try
        {
            var user = await _userService.GetAdmin(email);
            var userDto = UserConverter.ToDto(user);

            return Ok(userDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting admin failed: {e.Message}");
        }
    }

    [HttpDelete("admin")]
    public async Task<ActionResult> DeleteAdmin(string email)
    {
        try
        {
            await _userService.DeleteAdmin(email);

            return Ok($"Admin '{email}' deleted");
        }
        catch (Exception e)
        {
            return BadRequest($"Deleting admin failed: {e.Message}");
        }
    }

    [HttpPost("change-role")]
    public async Task<ActionResult> ChangeRole(string email, RoleDto roleDto)
    {
        try
        {
            var role = RoleConverter.ToModel(roleDto);
            var user = await _userService.ChangeRole(email, role);
            var userDto = UserConverter.ToDto(user);

            return Ok(userDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Changing user role failed: {e.Message}");
        }
    }
}