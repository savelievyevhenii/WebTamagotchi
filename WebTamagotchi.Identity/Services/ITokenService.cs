using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface ITokenService
{
    string CreateToken(ApplicationUser user);
    
    string GenerateRefreshToken(ApplicationUser foundUser);
}