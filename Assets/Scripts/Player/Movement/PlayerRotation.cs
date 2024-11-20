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


    Vector2 mouseInput;
    Vector3 rotate;
    [SerializeField] float sensitivity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //TestRotation();
    }


    void Move()
    {
        Vector3 viewDir = transform.position - new Vector3(MovementReferenceObject.position.x, transform.position.y, MovementReferenceObject.position.z);
        Orientation.transform.forward = viewDir.normalized;

        Vector3 moveDir = Orientation.forward * inputDirection.y + Orientation.right * inputDirection.x;

        if (moveDir != Vector3.zero)
            transform.forward = Vector3.Slerp(transform.forward, moveDir.normalized, Time.deltaTime * rotationSpeed);
    }

    void TestRotation()
    {
        rotate = new Vector3(mouseInput.x, mouseInput.y * sensitivity, 0);
        Orientation.eulerAngles = Orientation.eulerAngles - rotate;
    }

    public void GetMouseInput(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }


    public void SetMoveDirection(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        inputDirection = context.ReadValue<Vector2>();
    }
}