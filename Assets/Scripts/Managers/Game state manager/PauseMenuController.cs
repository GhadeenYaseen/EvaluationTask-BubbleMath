using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(this);

        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnDisable() 
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;    
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Paused);
    }
}
