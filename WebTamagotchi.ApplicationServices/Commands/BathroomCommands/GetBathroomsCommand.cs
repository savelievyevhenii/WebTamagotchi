using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class GetBathroomsCommand : IRequest<Result<IEnumerable<Bathroom>>>;