﻿using System.ComponentModel.DataAnnotations;

namespace WebTamagotchi.GameLogic.Models.Interfaces;

public class Activities
{
    [Key] 
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Experience { get; set; }
}