namespace WebTamagotchi.Identity.Exceptions;

public class PasswordValidationException : Exception
{
    public PasswordValidationException()
        : base("Wrong password")
    {
    }
}