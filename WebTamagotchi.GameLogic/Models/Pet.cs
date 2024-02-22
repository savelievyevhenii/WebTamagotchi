using System.ComponentModel.DataAnnotations;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.GameLogic.Models;

public class Pet
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int Level { get; set; }
    
    public int ExpToLevelUp { get; set; }
    
    public int Bore { get; set; }
    
    public int Hunger { get; set; }
    
    public int Tiredness { get; set; }
    
    public int Dirtiness { get; set; }
    
    public User Owner { get; set; } = null!;
}