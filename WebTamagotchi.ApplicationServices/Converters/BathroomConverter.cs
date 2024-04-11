using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Converters;

public static class BathroomConverter
{
    public static BathroomDto ToDto(Bathroom bathroom) => new BathroomDto
    {
        Id = bathroom.Id, Name = bathroom.Name, Experience = bathroom.Experience, Cleanliness = bathroom.Cleanliness
    };

    public static Bathroom ToModel(BathroomDto dto) => new Bathroom
    {
        Id = dto.Id , Name = dto.Name, Experience = dto.Experience, Cleanliness = dto.Cleanliness
    };
}