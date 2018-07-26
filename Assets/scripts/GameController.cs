using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public GameController Active;

    public event Action<GameModeChangedEventArgs> GameModeChangedEvent;

    public GameMode CurrentMode = GameMode.NORMAL;

    /// <summary>
    /// Sets active instance, on initialization or after script recompilation.
    /// </summary>
    void OnEnable()
    {
        Active = this;

    }

    public void SetGameMode(GameMode newMode)
    {
        if (newMode != CurrentMode) {
            if (GameModeChangedEvent != null) {
                var eventArgs = new GameModeChangedEventArgs(CurrentMode, newMode);
                GameModeChangedEvent.Invoke(eventArgs);
                if (eventArgs.Cancel) { return; }
            }
            CurrentMode = newMode;
        }
    }
}

public enum GameMode
{
    NORMAL,
    MAP_EDIT
}


public class GameModeChangedEventArgs : System.ComponentModel.CancelEventArgs
{
    public readonly GameMode OldGameMode;
    public readonly GameMode NewGameMode;

    public GameModeChangedEventArgs(GameMode oldMode, GameMode newMode)
    {
        OldGameMode = oldMode;
        NewGameMode = newMode;
    }
}
