namespace WebTamagotchi.Identity.Errors;

public class UserValidationError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly UserValidationError UserNotFound = new("user_not_found", "User not found");
}