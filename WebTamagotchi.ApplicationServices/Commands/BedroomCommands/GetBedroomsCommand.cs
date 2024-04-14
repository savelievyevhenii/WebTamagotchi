using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class GetBedroomsCommand : IRequest<Result<IEnumerable<Bedroom>>>;