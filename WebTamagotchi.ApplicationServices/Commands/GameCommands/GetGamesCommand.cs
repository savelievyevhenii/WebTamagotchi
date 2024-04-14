using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class GetGamesCommand : IRequest<Result<IEnumerable<Game>>>;