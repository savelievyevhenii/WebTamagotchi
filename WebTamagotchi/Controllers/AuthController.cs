using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
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
    public async Task<ActionResult<AuthResponseDto>> Authenticate([FromBody] AuthRequestDto requestDto)
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
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegistrationRequestDto requestDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var request = RegistrationRequestConverter.ToModel(requestDto);
            var authRequest = await _authService.Register(request);
            var authRequestDto = AuthRequestConverter.ToDto(authRequest);

            return await Authenticate(authRequestDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Registration failed: {e.Message}");
        }
    }
    
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModelDto tokenDto)
    {
        try
        {
            var tokenModel = TokenModelConverter.ToModel(tokenDto);
            return await _authService.RefreshToken(tokenModel);
        }
        catch (Exception e)
        {
            return BadRequest($"Refresh token failed: {e.Message}");
        }
    }
}