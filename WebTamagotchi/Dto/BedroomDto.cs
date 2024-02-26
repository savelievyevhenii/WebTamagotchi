using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto;

public class BedroomDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("experience")]
    public int Experience { get; set; }
    
    [JsonPropertyName("energy")]
    public int Energy { get; set; }
}