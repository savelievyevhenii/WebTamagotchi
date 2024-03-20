using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto.Identity;

public class RoleDto
{
    [JsonPropertyName("role")]
    public string? Role { get; init; }
}