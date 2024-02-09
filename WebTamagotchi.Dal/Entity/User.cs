using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebTamagotchi.Dal.Entity;

public class User : IdentityUser<long>
{
    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }
}