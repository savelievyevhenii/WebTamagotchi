using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Dal.Entity;
using WebTamagotchi.Dal.Services;
using WebTamagotchi.Dto;

namespace WebTamagotchi.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto)
    {
        var user = new User()
        {
            Username = userDto.Username,
            Email = userDto.Email
        };

        await _userService.Insert(user);

        return Ok();
    }
}