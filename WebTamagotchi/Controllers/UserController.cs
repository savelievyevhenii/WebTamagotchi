using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Enums;
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
    
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsers();
            var userDtos = users.Select(UserConverter.ToDto).ToList();

            return Ok(userDtos);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting users failed: {e.Message}");
        }
    }

    [HttpGet("user")]
    public async Task<ActionResult<UserDto>> GetUser(string email)
    {
        try
        {
            var user = await _userService.GetUser(email);
            var userDto = UserConverter.ToDto(user);

            return Ok(userDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Getting user failed: {e.Message}");
        }
    }

    [HttpDelete("user")]
    public async Task<ActionResult> DeleteUser(string email)
    {
        try
        {
            await _userService.DeleteUser(email);

            return Ok($"User '{email}' deleted");
        }
        catch (Exception e)
        {
            return BadRequest($"Deleting user failed: {e.Message}");
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