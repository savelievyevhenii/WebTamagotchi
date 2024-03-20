using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class RegistrationRequestDto
{
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("password")]
    public string? Password { get; init; }
    
    [JsonPropertyName("password_confirm")]
    public string? PasswordConfirm { get; init; }
}