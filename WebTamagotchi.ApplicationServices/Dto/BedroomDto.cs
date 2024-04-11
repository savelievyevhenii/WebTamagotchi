using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto;

public class BedroomDto
{
    [JsonPropertyName("bedroomId")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("experience")]
    public int Experience { get; set; }
    
    [JsonPropertyName("energy")]
    public int Energy { get; set; }
}