using WebTamagotchi.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.Converters;

public static class BathroomConverter
{
    public static BathroomDto ToDto(Bathroom bedroom) => new BathroomDto
    {
        Name = bedroom.Name, Experience = bedroom.Experience, Cleanliness = bedroom.Cleanliness
    };

    public static Bathroom ToModel(BathroomDto dto) => new Bathroom
    {
        Name = dto.Name, Experience = dto.Experience, Cleanliness = dto.Cleanliness
    };
}