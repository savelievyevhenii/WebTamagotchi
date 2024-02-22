using System.ComponentModel.DataAnnotations;

namespace WebTamagotchi.GameLogic.Models.Interfaces;

public class IActivities
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int Experience { get; set; }
}