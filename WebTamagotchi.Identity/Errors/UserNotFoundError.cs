namespace WebTamagotchi.Identity.Errors;

public class UserNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly UserNotFoundError UserNotFound = new("user_not_found", "User not found");
}