using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Services;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("test-auth")]
    public IActionResult TestAuthorization()
    {
        return Ok("You're Authorized");
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Authenticate([FromBody] AuthRequestDto requestDto)
    {
        var request = AuthRequestConverter.ToModel(requestDto);
        var result = await _authService.Authenticate(request);

        return result.IsSuccess
            ? Ok(AuthResponseConverter.ToDto(result.Value))
            : result.Error is UnauthorizedAccessException
                ? Unauthorized()
                : BadRequest($"Authentication failed: {result.Error}");
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegistrationRequestDto requestDto)
    {
        var request = RegistrationRequestConverter.ToModel(requestDto);
        var result = await _authService.Register(request);

        return result.IsSuccess
            ? await Authenticate(AuthRequestConverter.ToDto(result.Value))
            : BadRequest($"Registration failed: {result.Error}");
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModelDto tokenDto)
    {
        var tokenModel = TokenModelConverter.ToModel(tokenDto);
        var result = await _authService.RefreshToken(tokenModel);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest($"Refresh token failed: {result.Error}");
    }

    [HttpPost("revoke/{username}")]
    public async Task<IActionResult> Revoke(string username)
    {
        var result = await _authService.Revoke(username);

        return result.IsSuccess
            ? Ok($"User {username} revoked")
            : BadRequest($"Revoke failed: {result.Error}");
    }

    [HttpPost("revoke-all")]
    public async Task<IActionResult> RevokeAll()
    {
        var result = await _authService.RevokeAll();

        return result.IsSuccess
            ? Ok($"All users revoked")
            : BadRequest($"Revoke failed: {result.Error}");
    }
}