using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected GameObject knightObject;
    [SerializeField] protected GameObject pumpkinObject;

    private SpriteRenderer knightRenderer;
    private SpriteRenderer pumpkinRenderer;

    protected Rigidbody2D _rigidbody;

    protected Vector2 movementDirection = Vector2.zero;

    protected Vector2 lookDirection = Vector2.zero;

    protected bool isKnightActive;

    protected virtual void Awake()
    {
        knightRenderer = knightObject.GetComponent<SpriteRenderer>();
        pumpkinRenderer = pumpkinObject.GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        isKnightActive = knightObject.activeSelf;
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("HighScore") >= 10)
        {
            knightObject.SetActive(!isKnightActive);
            pumpkinObject.SetActive(isKnightActive);
            isKnightActive = knightObject.activeSelf;
        }
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
        if (isKnightActive)
        {
            _rigidbody.velocity = direction *= 5;
        }
        else
        {
            _rigidbody.velocity = direction *= 10;
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        knightRenderer.flipX = isLeft;
        pumpkinRenderer.flipX = isLeft;
    }
}
