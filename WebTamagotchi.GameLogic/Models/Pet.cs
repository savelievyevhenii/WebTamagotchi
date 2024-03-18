using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTamagotchi.GameLogic.Models;

public class Pet
{
    [Key]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public int ExpToLevelUp { get; set; }

    public int Bore { get; set; }

    public int Hunger { get; set; }

    public int Tiredness { get; set; }

    public int Dirtiness { get; set; }
}