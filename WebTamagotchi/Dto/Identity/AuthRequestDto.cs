using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto.Identity;

public class AuthRequestDto
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}