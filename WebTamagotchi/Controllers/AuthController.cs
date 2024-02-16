using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Models;
using WebTamagotchi.Identity.Services;

namespace WebTamagotchi.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet("test-auth")]
    public IActionResult TestAuthorization()
    {
        return Ok("You're Authorized");
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequestDto requestDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var request = AuthRequestConverter.ToModel(requestDto);
            var response = await _authService.Authenticate(request);
            var responseDto = AuthResponseConverter.ToDto(response);

            return Ok(responseDto);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (Exception e)
        {
            return BadRequest($"Authentication failed: {e.Message}");
        }
    }
}