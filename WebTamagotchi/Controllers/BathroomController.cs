using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters;
using WebTamagotchi.Dto;
using WebTamagotchi.GameLogic.Services;
using WebTamagotchi.GameLogic.Services.Impl;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BathroomController : ControllerBase
{
    private readonly IBathroomService _bathroomService;

    public BathroomController(IBathroomService bathroomService)
    {
        _bathroomService = bathroomService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBathroom(string name)
    {
        var result = await _bathroomService.Get(name);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetBathrooms()
    {
        var result = await _bathroomService.GetAll();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBathroom([FromBody] BathroomDto bathroomDto)
    {
        var result = await _bathroomService.Create(BathroomConverter.ToModel(bathroomDto));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateBathroom([FromBody] BathroomDto bathroomDto, string id)
    {
        var result = await _bathroomService.Update(BathroomConverter.ToModel(bathroomDto), id);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteBathroom(string name)
    {
        var result = await _bathroomService.Delete(name);

        return result.IsSuccess
            ? Ok($"Bathroom '{name}' was deleted.")
            : BadRequest(result.Error);
    }
}