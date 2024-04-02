namespace WebTamagotchi.GameLogic.Errors;

public class PetNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly PetNotFoundError PetNotFound = new("pet_not_found", "Pet not found");
}