using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters;
using WebTamagotchi.Dto;
using WebTamagotchi.GameLogic.Services;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpGet]
    public async Task<IActionResult> GetFood(string name)
    {
        var result = await _foodService.Get(name);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetFoods()
    {
        var result = await _foodService.GetAll();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] FoodDto foodDto)
    {
        var result = await _foodService.Create(FoodConverter.ToModel(foodDto));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateGame([FromBody] FoodDto foodDto, string id)
    {
        var result = await _foodService.Update(FoodConverter.ToModel(foodDto), id);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteGame(string name)
    {
        var result = await _foodService.Delete(name);

        return result.IsSuccess
            ? Ok($"Food '{name}' was deleted.")
            : BadRequest(result.Error);
    }
}