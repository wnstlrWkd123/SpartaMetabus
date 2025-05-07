using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    [SerializeField] private UIManager _UIManager;

    private int currentScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        _UIManager.UpdateScore(currentScore);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _UIManager.UpdateHighScore(highScore);
    }

    public void GameOver()
    {
        _UIManager.SetRestart();
    }

    public void RestartGame()
    {
        MiniGameManager.instance.UnloadMiniGame();
        MiniGameManager.instance.LoadMiniGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        _UIManager.UpdateScore(currentScore);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            _UIManager.UpdateHighScore(highScore);
        }
    }
}
