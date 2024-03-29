namespace WebTamagotchi.GameLogic.Errors;

public class FoodNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly FoodNotFoundError FoodNotFound = new("food_not_found", "Food not found");
}