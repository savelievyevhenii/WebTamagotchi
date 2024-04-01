namespace WebTamagotchi.GameLogic.Errors;

public class GameNotFoundError(string errorCode, string message) : Error(errorCode, message)
{
    public static readonly GameNotFoundError GameNotFound = new("game_not_found", "Game not found");
}