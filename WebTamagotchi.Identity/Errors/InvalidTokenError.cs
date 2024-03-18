namespace WebTamagotchi.Identity.Errors;

public class InvalidTokenError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly InvalidTokenError InvalidToken =
        new("invalid_token", "Invalid access token or refresh token");
}