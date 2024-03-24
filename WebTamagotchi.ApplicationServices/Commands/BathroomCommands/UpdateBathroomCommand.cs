using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class UpdateBathroomCommand(BathroomDto bathroomToUpdate) : IRequest<Result<BathroomDto, Error>>
{
    public BathroomDto BathroomToUpdate { get; } = bathroomToUpdate;
}