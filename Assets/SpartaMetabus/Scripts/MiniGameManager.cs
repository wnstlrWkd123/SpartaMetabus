using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    [SerializeField] private GameObject miniGameGuideUI;
    [SerializeField] private GameObject MainRoot;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void GetHighScore()
    {
        highScoreText.text = "최고 점수 : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void ShowMiniGameGuide()
    {
        miniGameGuideUI.SetActive(true);
        GetHighScore();
    }

    public void CancelMiniGameGuide()
    {
        miniGameGuideUI.SetActive(false);
    }

    public void LoadMiniGame()
    {
        MainRoot.SetActive(false);
        SceneManager.LoadScene("FlappyPlane", LoadSceneMode.Additive);
    }

    public void UnloadMiniGame()
    {
        SceneManager.UnloadSceneAsync("FlappyPlane");
        MainRoot.SetActive(true);
        GetHighScore();
    }
}
