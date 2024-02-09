using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Identity.Interfaces;

public interface ITokenService
{
    string CreateToken(User user, List<IdentityRole<long>> role);
}