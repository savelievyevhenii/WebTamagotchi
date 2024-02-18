namespace WebTamagotchi.Identity.Exceptions;

public class UserNotAdminException : Exception
{
    public UserNotAdminException(string email) : base($"User with email '{email}' is not a admin.")
    {
    }
}