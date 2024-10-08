﻿using System.Text.Json.Serialization;

namespace WebTamagotchi.ApplicationServices.Dto;

public class GameDto
{
    [JsonPropertyName("gameId")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("experience")]
    public int Experience { get; set; }

    [JsonPropertyName("fun")]
    public int Fun { get; set; }
    
    [JsonPropertyName("hunger")]
    public int Hunger { get; set; }
    
    [JsonPropertyName("dirtiness")]
    public int Dirtiness { get; set; }
    
    [JsonPropertyName("tiredness")]
    public int Tiredness { get; set; }
}