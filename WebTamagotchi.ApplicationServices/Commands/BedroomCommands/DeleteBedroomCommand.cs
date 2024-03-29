using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class DeleteBedroomCommand : IRequest<Maybe<Error>>
{
    public string Name { get; init; } = null!;
}