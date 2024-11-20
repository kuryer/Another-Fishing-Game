using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform Orientation;
    [SerializeField] Transform MovementReferenceObject;

    [Header("Rotation Parameters")]
    [SerializeField] float rotationSpeed;
    Vector2 inputDirection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector3 viewDir = transform.position - new Vector3(MovementReferenceObject.position.x, transform.position.y, MovementReferenceObject.position.z);
        Orientation.transform.forward = viewDir.normalized;

        Vector3 moveDir = Orientation.forward * inputDirection.y + Orientation.right * inputDirection.x;

        if (moveDir != Vector3.zero)
            transform.forward = Vector3.Slerp(transform.forward, moveDir.normalized, Time.deltaTime * rotationSpeed);
    }

    public void SetMoveDirection(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        inputDirection = context.ReadValue<Vector2>();
    }
}