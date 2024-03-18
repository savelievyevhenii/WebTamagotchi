using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class TokenModelDto
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }
}