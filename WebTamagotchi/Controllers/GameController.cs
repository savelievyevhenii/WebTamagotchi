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
    
    [HttpGet]
    public async Task<IActionResult> GetGame(string name)
    {
        var result = await _gameService.Get(name);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetGames()
    {
        var result = await _gameService.GetAll();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] GameDto gameDto)
    {
        var result = await _gameService.Create(GameConverter.ToModel(gameDto));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateGame([FromBody] GameDto gameDto, string id)
    {
        var result = await _gameService.Update(GameConverter.ToModel(gameDto), id);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteGame(string name)
    {
        var result = await _gameService.Delete(name);

        return result.IsSuccess
            ? Ok($"Game '{name}' was deleted.")
            : BadRequest(result.Error);
    }
}