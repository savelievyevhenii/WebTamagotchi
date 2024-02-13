using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Identity.Converters;
using WebTamagotchi.Identity.Dto;
using WebTamagotchi.Identity.Interfaces;

namespace WebTamagotchi.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Authenticate([FromBody] AuthRequestDto requestDto)
    {
        var request = AuthRequestConverter.ToModel(requestDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        try
        {
            var response = await _identityService.Authenticate(request);
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
        var request = RegistrationRequestConverter.ToModel(requestDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        try
        {
            var authRequest = await _identityService.Register(request);
            var authRequestDto = AuthRequestConverter.ToDto(authRequest);

            return await Authenticate(authRequestDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Registration failed: {e.Message}");
        }
    }
}