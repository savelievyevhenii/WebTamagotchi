using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Interfaces;

public interface IIdentityService
{
    Task<AuthResponse> Authenticate(AuthRequest request);

    Task<AuthRequest> Register(RegistrationRequest request);

    Task RefreshToken(TokenModel? tokenModel);

    Task Revoke(string username);

    Task RevokeAll();
}