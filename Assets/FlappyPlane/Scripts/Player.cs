using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    bool isFlap2 = false;

    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.Log("Not Founded Animtor");

        if (_rigidbody == null)
            Debug.Log("Not Founded Rigidbody2D");
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                // 게임 재시작
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    gameManager.RestartGame();
                }

                // 나가기
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MiniGameManager.instance.UnloadMiniGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // 강한 점프
            if (Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
            
            // 약한 점프
            if (Input.GetMouseButtonDown(1))
            {
                isFlap2 = true;
            }

            // 나가기
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MiniGameManager.instance.UnloadMiniGame();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        else if (isFlap2)
        {
            velocity.y = flapForce / 2f;
            isFlap2 = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90f, 90f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDead", 1);
        gameManager.GameOver();
    }
}