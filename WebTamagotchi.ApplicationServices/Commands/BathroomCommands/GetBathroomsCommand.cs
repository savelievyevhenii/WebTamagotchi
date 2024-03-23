using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.ApplicationServices.Commands.BathroomCommands;

public class GetBathroomsCommand : IRequest<Result<IEnumerable<BathroomDto>>>;