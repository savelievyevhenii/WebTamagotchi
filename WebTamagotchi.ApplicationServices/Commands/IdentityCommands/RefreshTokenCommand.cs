using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RefreshTokenCommand : IRequest<Result<TokenModel, Error>>
{
    public string AccessToken { get; init; } = null!;

    public string RefreshToken { get; init; } = null!;
}