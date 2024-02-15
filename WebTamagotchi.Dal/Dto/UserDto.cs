using System.Text.Json.Serialization;

namespace WebTamagotchi.Dal.Dto;

public class UserDto
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
}