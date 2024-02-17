using System.ComponentModel.DataAnnotations;

namespace WebTamagotchi.Identity.Models;

public class RegistrationRequest
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
    public string? PasswordConfirm { get; set; }
}