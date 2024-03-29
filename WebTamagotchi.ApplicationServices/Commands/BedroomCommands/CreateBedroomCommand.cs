using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class CreateBedroomCommand(BedroomDto bedroomToCreate) : IRequest<Result<BedroomDto, Error>>
{
    public BedroomDto BedroomToCreate { get; } = bedroomToCreate;
}