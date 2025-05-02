using UnityEngine;

public class PlayerController : BaseController
{
    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (horizontal != 0f)
        {
            lookDirection = new Vector2(horizontal, 0f);
        }
    }
}
