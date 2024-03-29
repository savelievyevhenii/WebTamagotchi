using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.FoodCommands;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class FoodController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Getfood(string name, CancellationToken cancellationToken)
    {
        var command = new GetFoodCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetFoods(CancellationToken cancellationToken)
    {
        var command = new GetAllFoodCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFood([FromBody] FoodDto foodDto,
        CancellationToken cancellationToken)
    {
        var command = new CreateFoodCommand(foodDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateFood([FromBody] FoodDto foodDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateFoodCommand(foodDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFood(string name, CancellationToken cancellationToken)
    {
        var command = new DeleteFoodCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"{response.Value.Message}")
            : Ok($"food '{name}' was deleted.");
    }
}