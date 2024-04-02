using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class GetPetsCommand : IRequest<Result<IEnumerable<PetDto>>>;