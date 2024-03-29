using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class UpdateBedroomCommand(BedroomDto bedroomToUpdate) : IRequest<Result<BedroomDto, Error>>
{
    public BedroomDto BedroomToUpdate { get; } = bedroomToUpdate;
}