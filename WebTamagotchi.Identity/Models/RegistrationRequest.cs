using System.ComponentModel.DataAnnotations;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.Identity.Models;

public class RegistrationRequest
{
    [Required]
    public string? Email { get; set; }
    
    [Required]
    public string? Username { get; set; }
    
    [Required]
    public string? Password { get; set; }
    
    public Role Role { get; set; }
}