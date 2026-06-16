using Darkthorn.Quest.Engine.Enumerations;

namespace Darkthorn.Quest.Engine.Services.Interfaces;

public interface IGameStateService
{
    GameState CurrentState { get; }
    GameState PreviousState { get; }

    void ChangeState(GameState newState);
}