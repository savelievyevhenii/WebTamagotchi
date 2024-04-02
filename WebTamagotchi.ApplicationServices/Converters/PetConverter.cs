using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Converters;

public static class PetConverter
{
    public static PetDto ToDto(Pet pet) => new PetDto
    {
        Name = pet.Name, Level = pet.Level, ExpToLevelUp = pet.ExpToLevelUp, Dirtiness = pet.Dirtiness, Bore = pet.Bore,
        Hunger = pet.Hunger, Tiredness = pet.Tiredness, Owner = pet.Owner
    };
    
    public static Pet ToModel(PetDto dto) => new Pet
    {
        Name = dto.Name, Level = dto.Level, ExpToLevelUp = dto.ExpToLevelUp, Dirtiness = dto.Dirtiness, Bore = dto.Bore,
        Hunger = dto.Hunger, Tiredness = dto.Tiredness, Owner = dto.Owner
    };
}