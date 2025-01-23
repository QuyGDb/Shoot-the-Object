using System;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    public GameState gameState;
    [HideInInspector] public Action<GameState> OnGameStateChange;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void HandleGameState(GameState gameState)
    {
        this.gameState = gameState;
        switch (gameState)
        {

            default:
                break;
        }
        OnGameStateChange?.Invoke(gameState);

    }
}
