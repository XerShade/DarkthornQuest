namespace Darkthorn.Quest.Engine.Enumerations;

/// <summary>
/// Defines values for game states.
/// </summary>
public enum GameState
{
    /// <summary>
    /// Defines the value for when the game is not running.
    /// </summary>
    None = 0,
    /// <summary>
    /// Defines the value for when the game is on the main menu.
    /// </summary>
    Menu = 1 << 0,
    /// <summary>
    /// Defines the value for when the game is in play.
    /// </summary>
    Game = 1 << 1,
    /// <summary>
    /// Defines the value for when the game is paused.
    /// </summary>
    Pause = 1 << 2,
    /// <summary>
    /// Defines the value for when the game is over.
    /// </summary>
    GameOver = 1 << 3
}