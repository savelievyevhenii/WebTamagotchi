using System.Text.Json.Serialization;

namespace WebTamagotchi.Identity.Dto;

public class AuthResponseDto
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;
    
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = null!;
}