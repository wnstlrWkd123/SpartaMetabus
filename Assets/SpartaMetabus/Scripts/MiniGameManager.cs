using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    [SerializeField] private GameObject miniGameGuideUI;
    [SerializeField] private GameObject MainRoot;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ShowMiniGameGuide()
    {
        miniGameGuideUI.SetActive(true);
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
    }
}
