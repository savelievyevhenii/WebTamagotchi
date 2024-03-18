namespace WebTamagotchi.Identity.Errors;

public abstract class Error(string errorCode, string message)
{
    public string ErrorCode { get; set; } = errorCode;

    public string Message { get; set; } = message;
}