using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Converters;

public static class BedroomConverter
{
    public static BedroomDto ToDto(Bedroom bedroom) => new BedroomDto
    {
        Name = bedroom.Name, Experience = bedroom.Experience, Energy = bedroom.Energy
    };

    public static Bedroom ToModel(BedroomDto dto) => new Bedroom
    {
        Name = dto.Name, Experience = dto.Experience, Energy = dto.Energy
    };
}