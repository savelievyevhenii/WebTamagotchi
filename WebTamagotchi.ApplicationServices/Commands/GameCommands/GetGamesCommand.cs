using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.ApplicationServices.Commands.GameCommands;

public class GetGamesCommand : IRequest<Result<IEnumerable<GameDto>>>;