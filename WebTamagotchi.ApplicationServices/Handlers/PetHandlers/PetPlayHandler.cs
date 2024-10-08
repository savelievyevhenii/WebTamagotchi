﻿using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.PetCommands;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Handlers.PetHandlers;

public class PetPlayHandler(IPetRepository petRepository, IGameRepository gameRepository)
    : IRequestHandler<PetPlayCommand, Result<Pet, Error>>
{
    public async Task<Result<Pet, Error>> Handle(PetPlayCommand request, CancellationToken cancellationToken)
    {
        var pet = await petRepository.Get(request.PetId, cancellationToken);
        var game = await gameRepository.Get(request.GameId, cancellationToken);
        if (pet == null)
        {
            return PetNotFoundError.PetNotFound;
        }

        if (game == null)
        {
            return GameNotFoundError.GameNotFound;
        }

        pet.ExpToLevelUp = Math.Max(0, pet.ExpToLevelUp - game.Experience);
        pet.Bore = Math.Max(0, pet.Bore - game.Fun);
        pet.Hunger = Math.Min(100, pet.Hunger + game.Hunger);
        pet.Dirtiness = Math.Min(100, pet.Dirtiness + game.Dirtiness);
        pet.Tiredness = Math.Min(100, pet.Tiredness + game.Tiredness);

        await petRepository.Update(pet, cancellationToken);

        return pet;
    }
}