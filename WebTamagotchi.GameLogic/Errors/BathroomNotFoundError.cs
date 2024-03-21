namespace WebTamagotchi.GameLogic.Errors;

public class BathroomNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly BathroomNotFoundError BathroomNotFound = new("bathroom_not_found", "Bathroom not found");
}