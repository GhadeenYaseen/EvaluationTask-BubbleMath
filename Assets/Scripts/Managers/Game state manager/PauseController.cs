using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void PauseGame()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(this);

        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
    }
}
