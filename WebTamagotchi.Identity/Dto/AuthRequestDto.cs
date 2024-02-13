using System.Text.Json.Serialization;

namespace WebTamagotchi.Identity.Dto;

public class AuthRequestDto
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}