using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class RegistrationRequestDto
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    
    [JsonPropertyName("password_confirm")]
    public string? PasswordConfirm { get; set; }
}