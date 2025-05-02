using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    [SerializeField] GameObject miniGameGuideUI;

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

    public void OnClickStartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
}
