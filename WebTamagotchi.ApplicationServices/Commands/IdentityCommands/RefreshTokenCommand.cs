using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.Identity.Errors;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RefreshTokenCommand : IRequest<Result<TokenModel, Error>>
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}