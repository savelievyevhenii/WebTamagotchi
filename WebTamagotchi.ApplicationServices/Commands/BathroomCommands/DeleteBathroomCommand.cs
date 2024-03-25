using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class DeleteBathroomCommand : IRequest<Maybe<Error>>
{
    public string Name { get; init; } = null!;
}