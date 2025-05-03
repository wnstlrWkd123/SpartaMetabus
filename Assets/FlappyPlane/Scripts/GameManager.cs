using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UiManager uiManager;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        MiniGameManager.instance.UnloadMiniGame();
        MiniGameManager.instance.LoadMiniGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
