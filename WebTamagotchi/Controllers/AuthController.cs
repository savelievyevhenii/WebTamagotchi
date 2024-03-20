using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.IdentityCommands;
using WebTamagotchi.ApplicationServices.Converters.Identity;
using WebTamagotchi.ApplicationServices.Dto.Identity;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class AuthController(ISender mediator) : ControllerBase
{
    [HttpGet("test-auth")]
    public IActionResult TestAuthorization()
    {
        return Ok("You're Authorized");
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var command = new AuthCommand { Email = requestDto.Email!, Password = requestDto.Password! };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest($"Authentication failed: {response.Error.Message}");
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var command = new RegisterCommand
        {
            Email = requestDto.Email!, Password = requestDto.Password!, PasswordConfirm = requestDto.PasswordConfirm!
        };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? await Authenticate(AuthRequestConverter.ToDto(response.Value), new CancellationToken())
            : BadRequest($"Registration failed: {response.Error.Message}");
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModelDto tokenDto,
        CancellationToken cancellationToken)
    {
        var command = new RefreshTokenCommand
        {
            AccessToken = tokenDto.AccessToken!,
            RefreshToken = tokenDto.RefreshToken!
        };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest($"Refresh token failed: {response.Error.Message}");
    }

    [HttpPost("revoke/{username}")]
    public async Task<IActionResult> Revoke(string username, CancellationToken cancellationToken)
    {
        var command = new RevokeCommand { Username = username };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"Revoke failed: {response.Value.Message}")
            : Ok($"User {username} revoked");
    }

    [HttpPost("revoke-all")]
    public async Task<IActionResult> RevokeAll(CancellationToken cancellationToken)
    {
        var command = new RevokeAllCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"Revoke failed: {response.Value.Message}")
            : Ok("All users revoked");
    }
}