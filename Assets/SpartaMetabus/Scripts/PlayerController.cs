using UnityEngine;

public class PlayerController : BaseController
{
    private Animator knightAnimator;
    private Animator pumpkinAnimator;

    protected override void Awake()
    {
        base.Awake();
        knightAnimator = knightObject.GetComponent<Animator>();
        pumpkinAnimator = pumpkinObject.GetComponent<Animator>();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (horizontal != 0f)
        {
            lookDirection = new Vector2(horizontal, 0f);
        }

        bool isAct = movementDirection != Vector2.zero;

        if (isKnightActive)
        {
            knightAnimator.SetBool("IsMove", isAct);
        }
        else
        {
            pumpkinAnimator.SetBool("IsRun", isAct);
        }
    }
}
