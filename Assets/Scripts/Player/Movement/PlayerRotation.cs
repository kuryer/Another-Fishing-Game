using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [Header("Rotation Parameters")]
    [SerializeField] float rotationSpeed;
    bool isRotating;
    Vector2 MousePos;
    Vector2 previousMousePos;
    [SerializeField] Vector2 mouseDefaultPos;


    void Start()
    {
        isRotating = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotate();

    }

    public void SetIsRotating(bool value)
    {
        isRotating=value;
    }

    void Rotate()
    {
        if (!isRotating || Time.timeScale <= 0)
            return;
        float y = Input.GetAxis("Mouse X");
        Vector3 rotate = new Vector3(0, y, 0);
        transform.eulerAngles = transform.eulerAngles + rotate;
    }
    public void GetMouseInput(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        previousMousePos = MousePos;
        MousePos = context.ReadValue<Vector2>();
    }
}