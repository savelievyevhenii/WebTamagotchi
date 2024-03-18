using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class AuthResponseDto
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("token")]
    public string? Token { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }
}