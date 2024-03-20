using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class AuthRequestDto
{
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("password")]
    public string? Password { get; init; }
}