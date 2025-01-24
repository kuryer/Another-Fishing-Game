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
    Vector2 inputDir;

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
        rb.linearVelocity = ((orientation.forward * inputDir.y + orientation.right * inputDir.x) * movementSpeed);
    }

    public void GetMovementInput(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        if (inputDir == Vector2.zero)
            playerAnimation.PlayAnimation("idle");
        else
            playerAnimation.PlayAnimation("walk");
    }
}
