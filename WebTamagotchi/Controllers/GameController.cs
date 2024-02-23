using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters;
using WebTamagotchi.Dto;
using WebTamagotchi.GameLogic.Services;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateGame([FromBody] GameDto gameDto)
    {
        var result = await _gameService.Create(GameConverter.ToModel(gameDto));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}