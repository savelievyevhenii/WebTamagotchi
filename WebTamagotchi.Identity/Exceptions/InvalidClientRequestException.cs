namespace WebTamagotchi.Identity.Exceptions;

public class InvalidClientRequestException : Exception
{
    public InvalidClientRequestException() : base("Invalid client request")
    {
    }
}