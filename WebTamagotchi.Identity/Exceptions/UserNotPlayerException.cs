namespace WebTamagotchi.Identity.Exceptions;

public class UserNotPlayerException : Exception
{
    public UserNotPlayerException(string email) : base($"User with email '{email}' is not a player.")
    {
    }
}