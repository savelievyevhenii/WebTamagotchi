using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters;
using WebTamagotchi.Dto;
using WebTamagotchi.GameLogic.Services;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BedroomController : ControllerBase
{
    private readonly IBedroomService _bedroomService;

    public BedroomController(IBedroomService bedroomService)
    {
        _bedroomService = bedroomService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBedroom(string name)
    {
        var result = await _bedroomService.Get(name);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetBedrooms()
    {
        var result = await _bedroomService.GetAll();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBedroom([FromBody] BedroomDto bedroomDto)
    {
        var result = await _bedroomService.Create(BedroomConverter.ToModel(bedroomDto));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateBedroom([FromBody] BedroomDto bedroomDto, string id)
    {
        var result = await _bedroomService.Update(BedroomConverter.ToModel(bedroomDto), id);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteBedroom(string name)
    {
        var result = await _bedroomService.Delete(name);

        return result.IsSuccess
            ? Ok($"Bedroom '{name}' was deleted.")
            : BadRequest(result.Error);
    }
}