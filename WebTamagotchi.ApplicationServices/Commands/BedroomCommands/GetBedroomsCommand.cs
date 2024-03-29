using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.ApplicationServices.Commands.BedroomCommands;

public class GetBedroomsCommand : IRequest<Result<IEnumerable<BedroomDto>>>;