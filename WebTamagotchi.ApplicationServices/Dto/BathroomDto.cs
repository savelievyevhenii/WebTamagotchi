using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto;

public class BathroomDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("experience")]
    public int Experience { get; set; }
    
    [JsonPropertyName("cleanliness")]
    public int Cleanliness { get; set; }
}