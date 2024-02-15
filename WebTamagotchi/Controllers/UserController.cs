using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Dal.Converters;
using WebTamagotchi.Dal.Dto;
using WebTamagotchi.Dal.Services;
using WebTamagotchi.Identity.Converters;

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
        var user = UserConverter.ToModel(userDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _userService.MakePlayer(user);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest($"MakePlayer failed: {e.Message}");
        }
    }
    
    [HttpPost("make-administrator")]
    public async Task<ActionResult> MakeAdministrator([FromBody] UserDto userDto)
    {
        var user = UserConverter.ToModel(userDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _userService.MakeAdministrator(user);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest($"MakeAdministrator failed: {e.Message}");
        }
    }
}