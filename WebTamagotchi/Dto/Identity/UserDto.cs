﻿using System.Text.Json.Serialization;

namespace WebTamagotchi.Dto.Identity;

public class UserDto
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("role")]
    public string? Role { get; set; }
}