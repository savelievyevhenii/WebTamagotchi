using WebTamagotchi.GameLogic.Models.Interfaces;

namespace WebTamagotchi.GameLogic.Models;

public class Food: Activities
{
    public int Satiety { get; set; }

    public int Dirtiness { get; set; }
    
    public string IconJson { get; set; } = null!;
}