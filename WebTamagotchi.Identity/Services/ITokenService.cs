using System.Security.Claims;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface ITokenService
{
    string CreateToken(User user);
    
    string GenerateRefreshToken(User foundUser);
    
    ClaimsPrincipal GetPrincipalFromExpiredToken(string? accessToken);
}