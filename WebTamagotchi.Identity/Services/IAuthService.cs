using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface IAuthService
{
    Task<AuthResponse> Authenticate(AuthRequest request);

    Task<AuthRequest> Register(RegistrationRequest request);

    Task<IActionResult> RefreshToken(TokenModel tokenModel);

    Task Revoke(string username);

    Task RevokeAll();
}