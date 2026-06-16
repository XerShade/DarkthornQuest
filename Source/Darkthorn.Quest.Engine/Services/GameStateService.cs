using Darkthorn.Quest.Engine.Enumerations;
using Darkthorn.Quest.Engine.Services.Interfaces;

namespace Darkthorn.Quest.Engine.Services;

public class GameStateService : IGameStateService
{
    public GameState CurrentState { get; protected set; } = GameState.None;
    public GameState PreviousState { get; protected set; } = GameState.None;

    public void ChangeState(GameState newState)
    {
        if (this.CurrentState == newState)
        { return; }

        this.PreviousState = this.CurrentState;
        this.CurrentState = newState;
    }
}