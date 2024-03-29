namespace WebTamagotchi.GameLogic.Errors;

public class BedroomNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly BedroomNotFoundError BedroomNotFound = new("bedroom_not_found", "Bedroom not found");
}