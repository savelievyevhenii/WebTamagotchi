using System.Text.Json.Serialization;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Dto;

public class PetDto
{    
    [JsonPropertyName("petId")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
    
    [JsonPropertyName("level")]
    public int Level { get; init; }
    
    [JsonPropertyName("expToLevelUp")]
    public int ExpToLevelUp { get; init; }
    
    [JsonPropertyName("bore")]
    public int Bore { get; init; }
    
    [JsonPropertyName("hunger")]
    public int Hunger { get; init; }
    
    [JsonPropertyName("tiredness")]
    public int Tiredness { get; init; }
    
    [JsonPropertyName("dirtiness")]
    public int Dirtiness { get; init; }
    
    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;
}