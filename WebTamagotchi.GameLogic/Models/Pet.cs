using System.ComponentModel.DataAnnotations;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.GameLogic.Models;

public class Pet
{
    [Key]
    public string Id { get; set; } = null!;

    public string Name { get; init; } = null!;

    public int Level { get; init; }

    public int ExpToLevelUp { get; init; }

    public int Bore { get; init; }

    public int Hunger { get; init; }

    public int Tiredness { get; init; }

    public int Dirtiness { get; init; }

    public User Owner { get; init; }
}