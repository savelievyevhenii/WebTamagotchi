using System.Security.Claims;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Infrastructure.TokenManager;

public interface ITokenManager
{
    string CreateToken(User user);
    
    string GenerateRefreshToken(User foundUser);
    
    ClaimsPrincipal GetPrincipalFromExpiredToken(string? accessToken);
}