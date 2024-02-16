namespace WebTamagotchi.Identity.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string email) : base($"Invalid user email: {email}")
    {
    }
}