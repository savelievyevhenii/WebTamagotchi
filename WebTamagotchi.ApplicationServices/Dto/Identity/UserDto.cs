using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class UserDto
{
    [JsonPropertyName("userId")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("username")]
    public string? Username { get; init; }
    
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("role")]
    public string? Role { get; init; }
}