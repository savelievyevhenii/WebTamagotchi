using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto.Identity;

public class AuthResponseDto
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}