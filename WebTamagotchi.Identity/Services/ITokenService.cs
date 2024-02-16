using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Identity.Services;

public interface ITokenService
{
    public Task CreateToken(ApplicationUser user);
}