﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BathroomController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBathroom(string bathroomId, CancellationToken cancellationToken)
    {
        var command = new GetBathroomCommand { Id  = bathroomId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetBathrooms(CancellationToken cancellationToken)
    {
        var command = new GetBathroomsCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBathroom([FromBody] BathroomDto bathroomDto,
        CancellationToken cancellationToken)
    {
        var command = new CreateBathroomCommand(bathroomDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateBathroom([FromBody] BathroomDto bathroomDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateBathroomCommand(bathroomDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBathroom(string name, CancellationToken cancellationToken)
    {
        var command = new DeleteBathroomCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);
        
        return response.HasValue
            ? BadRequest($"{response.Value.Message}")
            : Ok($"Bathroom '{name}' was deleted.");
    }
}