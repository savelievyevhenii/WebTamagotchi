using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto;

public class RegistrationRequestDto
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
 
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;

    [JsonPropertyName("password_confirm")]
    public string PasswordConfirm { get; set; } = null!;
}