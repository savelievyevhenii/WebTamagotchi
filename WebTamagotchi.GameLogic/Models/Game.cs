using WebTamagotchi.GameLogic.Models.Interfaces;

namespace WebTamagotchi.GameLogic.Models;

public class Game : IActivities
{
    public int Fun { get; set; }

    public int Hunger { get; set; }
    
    public int Dirtiness { get; set; }
    
    public int Tiredness { get; set; }
}