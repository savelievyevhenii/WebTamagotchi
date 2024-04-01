using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.GameCommands;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class GameController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetGame(string name, CancellationToken cancellationToken)
    {
        var command = new GetGameCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetGames(CancellationToken cancellationToken)
    {
        var command = new GetGamesCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] GameDto gameDto,
        CancellationToken cancellationToken)
    {
        var command = new CreateGameCommand(gameDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateGame([FromBody] GameDto gameDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateGameCommand(gameDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGame(string name, CancellationToken cancellationToken)
    {
        var command = new DeleteGameCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"{response.Value.Message}")
            : Ok($"game '{name}' was deleted.");
    }
}