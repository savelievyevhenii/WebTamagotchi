using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.BedroomCommands;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BedroomController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Getbedroom(string name, CancellationToken cancellationToken)
    {
        var command = new GetBedroomCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetBedrooms(CancellationToken cancellationToken)
    {
        var command = new GetBedroomsCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBedroom([FromBody] BedroomDto bedroomDto,
        CancellationToken cancellationToken)
    {
        var command = new CreateBedroomCommand(bedroomDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateBedroom([FromBody] BedroomDto bedroomDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateBedroomCommand(bedroomDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBedroom(string name, CancellationToken cancellationToken)
    {
        var command = new DeleteBedroomCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"{response.Value.Message}")
            : Ok($"bedroom '{name}' was deleted.");
    }
}