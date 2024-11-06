using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (rb.velocity.magnitude > maxMovementSpeed)
            return;
        rb.AddForce((orientation.forward * inputDir.y + orientation.right * inputDir.x) * movementSpeed);
    }

    public void GetMovementInput(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }
}
