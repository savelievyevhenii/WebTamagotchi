using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Dal.Constants;
using WebTamagotchi.Dal.Converters;
using WebTamagotchi.Dal.Dto;
using WebTamagotchi.Dal.Services;

namespace WebTamagotchi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("make-player")]
    public async Task<ActionResult> MakePlayer([FromBody] UserDto userDto)
    {
        try
        {
            var user = UserConverter.ToModel(userDto);
            await _userService.UpdateUserRole(user, UserRoles.Administrator, UserRoles.Player);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest($"Make player failed: {e.Message}");
        }
    }

    [HttpPost("make-administrator")]
    public async Task<ActionResult> MakeAdministrator([FromBody] UserDto userDto)
    {
        try
        {
            var user = UserConverter.ToModel(userDto);
            await _userService.UpdateUserRole(user, UserRoles.Player, UserRoles.Administrator);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest($"Make administrator failed: {e.Message}");
        }
    }
}
