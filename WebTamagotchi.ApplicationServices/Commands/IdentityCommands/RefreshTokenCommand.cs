using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.IdentityCommands;

public class RefreshTokenCommand : IRequest<Result<TokenModelDto, Error>>
{
    public string AccessToken { get; init; } = null!;

    public string RefreshToken { get; init; } = null!;
}