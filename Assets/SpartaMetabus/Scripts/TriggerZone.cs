using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MiniGameManager.instance.ShowMiniGameGuide();
        }
    }
}
