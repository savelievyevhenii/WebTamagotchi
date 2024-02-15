namespace WebTamagotchi.Dal.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string email)
        : base($"Invalid user email: {email}")
    {
    }
}