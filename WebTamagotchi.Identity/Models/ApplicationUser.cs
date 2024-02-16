using Microsoft.AspNetCore.Identity;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public Role Role { get; set; }
}