using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto;

public class FoodDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("experience")]
    public int Experience { get; set; }
    
    [JsonPropertyName("satiety")]
    public int Satiety { get; set; }
    
    [JsonPropertyName("dirtiness")]
    public int Dirtiness { get; set; }
   
}