using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private BoxCollider2D limitZone;

    public float smoothing = 5f;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        minPosition = limitZone.bounds.min;
        maxPosition = limitZone.bounds.max;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y),
                transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
