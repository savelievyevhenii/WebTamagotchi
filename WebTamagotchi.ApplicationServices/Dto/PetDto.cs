using System.Text.Json.Serialization;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Dto;

public class PetDto
{    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("level")]
    public int Level { get; set; }
    
    [JsonPropertyName("expToLevelUp")]
    public int ExpToLevelUp { get; set; }
    
    [JsonPropertyName("bore")]
    public int Bore { get; set; }
    
    [JsonPropertyName("hunger")]
    public int Hunger { get; set; }
    
    [JsonPropertyName("tiredness")]
    public int Tiredness { get; set; }
    
    [JsonPropertyName("dirtiness")]
    public int Dirtiness { get; set; }
    
    [JsonPropertyName("owner")]
    public User Owner { get; set; } = null!;
}