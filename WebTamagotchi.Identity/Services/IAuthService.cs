using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface IAuthService
{
    Task<Result<AuthResponse>> Authenticate(AuthRequest request);

    Task<Result<AuthRequest>> Register(RegistrationRequest request);

    Task<Result<IActionResult>> RefreshToken(TokenModel tokenModel);

    Task<Result> Revoke(string username);

    Task<Result> RevokeAll();
}