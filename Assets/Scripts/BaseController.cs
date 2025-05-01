using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    protected Rigidbody2D _rigidbody;

    protected Vector2 movementDirection = Vector2.zero;

    protected Vector2 lookDirection = Vector2.zero;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        // 이동속도 관련
        _rigidbody.velocity = direction *= 10;
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
}
