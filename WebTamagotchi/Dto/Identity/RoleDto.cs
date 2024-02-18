using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto.Identity;

public class RoleDto
{
    [JsonPropertyName("role")]
    public string? Role { get; set; }
}