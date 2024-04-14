using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class GetUsersCommand : IRequest<Result<IEnumerable<User>, Error>>;