using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class AuthResponseDto
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }
    
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("token")]
    public string? Token { get; init; }
    
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; }
}