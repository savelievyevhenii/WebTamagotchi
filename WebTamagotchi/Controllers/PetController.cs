using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class PetController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPet(string petId, CancellationToken cancellationToken)
    {
        var command = new GetPetCommand { Id = petId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetPets(CancellationToken cancellationToken)
    {
        var command = new GetPetsCommand();

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePet([FromBody] PetDto petDto,
        CancellationToken cancellationToken)
    {
        var command = new CreatePetCommand(petDto);

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePet(string name, CancellationToken cancellationToken)
    {
        var command = new DeletePetCommand { Name = name };

        var response = await mediator.Send(command, cancellationToken);

        return response.HasValue
            ? BadRequest($"{response.Value.Message}")
            : Ok($"Pet '{name}' was deleted.");
    }

    [HttpPost("play")]
    public async Task<IActionResult> Play(string petId, string gameId, CancellationToken cancellationToken)
    {
        var command = new PetPlayCommand { PetId = petId, GameId = gameId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }

    [HttpPost("feed")]
    public async Task<IActionResult> Feed(string petId, string foodId, CancellationToken cancellationToken)
    {
        var command = new PetFeedCommand { PetId = petId, FoodId = foodId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }
    
    [HttpPost("sleep")]
    public async Task<IActionResult> Sleep(string petId, string bedroomId, CancellationToken cancellationToken)
    {
        var command = new PetSleepCommand { PetId = petId, BedroomId = bedroomId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }
    
    [HttpPost("wash")]
    public async Task<IActionResult> Wash(string petId, string bathroomId, CancellationToken cancellationToken)
    {
        var command = new PetWashCommand { PetId = petId, BathroomId = bathroomId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }
    
    [HttpPost("lvl-up")]
    public async Task<IActionResult> LvlUp(string petId, CancellationToken cancellationToken)
    {
        var command = new PetLvlUpCommand { PetId = petId };

        var response = await mediator.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : BadRequest(response.Error.Message);
    }
}