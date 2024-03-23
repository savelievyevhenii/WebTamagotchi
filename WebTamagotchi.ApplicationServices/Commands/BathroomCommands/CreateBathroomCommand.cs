using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class CreateBathroomCommand(BathroomDto bathroomToCreate) : IRequest<Result<BathroomDto, Error>>
{
    public BathroomDto BathroomToCreate { get; set; } = bathroomToCreate;
}