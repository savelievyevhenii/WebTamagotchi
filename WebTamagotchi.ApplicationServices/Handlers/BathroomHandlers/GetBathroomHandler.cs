﻿using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Commands.BathroomCommands;
using WebTamagotchi.ApplicationServices.Converters;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.Dal.Repositories.Interfaces;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Handlers.BathroomHandlers;

public class GetBathroomHandler(IBathroomRepository bathroomRepository)
    : IRequestHandler<GetBathroomCommand, Result<BathroomDto, Error>>
{
    public async Task<Result<BathroomDto, Error>> Handle(GetBathroomCommand request,
        CancellationToken cancellationToken)
    {
        var bathroom = await bathroomRepository.Get(request.Name, cancellationToken);
        return bathroom != null
            ? BathroomConverter.ToDto(bathroom)
            : new BathroomNotFoundError("bathroom_not_found", $"Bathroom not found with name {request.Name}");
    }
}