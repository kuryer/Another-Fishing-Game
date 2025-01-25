using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform orientation;

    [Header("Variables")]
    [SerializeField] float movementSpeed;
    [SerializeField] float maxMovementSpeed;
    float inputDir;

    [Header("Animation")]
    [SerializeField] PlayerAnimation playerAnimation;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (rb.linearVelocity.magnitude > maxMovementSpeed)
            return;
        rb.linearVelocity = ((orientation.forward * inputDir) * movementSpeed);
    }

    public void GetMovementInput(InputAction.CallbackContext context)
    {
        if (!enabled)
            return;
        inputDir = context.ReadValue<float>();
        if (inputDir == 0)
            playerAnimation.PlayAnimation("idle");
        else
            playerAnimation.PlayAnimation("walk");
    }
}
