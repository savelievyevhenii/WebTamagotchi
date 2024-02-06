using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto;

public class UserDto
{    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
}