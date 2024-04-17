using System.ComponentModel.DataAnnotations;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.GameLogic.Models;

public class Pet
{
    [Key]
    public string Id { get; set; } = null!;

    public string Name { get; init; } = null!;

    public int Level { get; set; }

    public int ExpToLevelUp { get; set; }

    public int Bore { get; set; }

    public int Hunger { get; set; }

    public int Tiredness { get; set; }

    public int Dirtiness { get; set; }

    public User Owner { get; init; }
}