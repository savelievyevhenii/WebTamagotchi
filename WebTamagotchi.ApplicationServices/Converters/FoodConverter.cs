using WebTamagotchi.ApplicationServices.Dto;
using WebTamagotchi.GameLogic.Models;

namespace WebTamagotchi.ApplicationServices.Converters;

public static class FoodConverter
{
    public static FoodDto ToDto(Food food) => new FoodDto
    {
        Name = food.Name, Experience = food.Experience, Dirtiness = food.Dirtiness, Satiety = food.Satiety
    };

    public static Food ToModel(FoodDto dto) => new Food
    {
        Name = dto.Name, Experience = dto.Experience, Dirtiness = dto.Dirtiness, Satiety = dto.Satiety
    };
}