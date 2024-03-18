using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.Identity.Models;

public class User : IdentityUser
{
    public Role Role { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }
}