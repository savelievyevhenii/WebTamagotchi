using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Converters;

public static class GameConverter
{
    public static GameDto ToDto(Game game) => new GameDto
    {
        Name = game.Name, Experience = game.Experience, Dirtiness = game.Dirtiness, Fun = game.Fun,
        Hunger = game.Hunger, Tiredness = game.Tiredness
    };

    public static Game ToModel(GameDto dto) => new Game
    {
        Name = dto.Name, Experience = dto.Experience, Dirtiness = dto.Dirtiness, Fun = dto.Fun,
        Hunger = dto.Hunger, Tiredness = dto.Tiredness
    };
}