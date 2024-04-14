using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Commands.PetCommands;

public class GetPetsCommand : IRequest<Result<IEnumerable<Pet>>>;