namespace WebTamagotchi.Identity.Exceptions;

public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("Invalid access token or refresh token")
    {
    }
}