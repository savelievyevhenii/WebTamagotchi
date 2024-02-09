using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Dto;
using WebTamagotchi.Identity.Interfaces;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController: ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Authenticate([FromBody] AuthRequestDto requestDto)
    {
        var request = new AuthRequest
        {
            Email = requestDto.Email,
            Password = requestDto.Password
        };
        
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        try
        {
            var response = await _identityService.Authenticate(request);
            var responseDto = new AuthResponseDto
            {
                Username = response.Username,
                Email = response.Email,
                Token = response.Token,
                RefreshToken = response.RefreshToken
            };
            
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
        var request = new RegistrationRequest
        {
            Email = requestDto.Email,
            Password = requestDto.Password,
            PasswordConfirm = requestDto.PasswordConfirm,
        };
        
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        try
        {
            var authRequest = await _identityService.Register(request);
            var authRequestDto = new AuthRequestDto
            {
                Email = authRequest.Email,
                Password = authRequest.Password
            };

            return await Authenticate(authRequestDto);
        }
        catch (Exception e)
        {
            return BadRequest($"Registration failed: {e.Message}");
        }
    }
}