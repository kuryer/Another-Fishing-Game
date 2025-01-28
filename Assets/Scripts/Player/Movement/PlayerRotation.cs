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
        //Cursor.visible = false;
    }

    void LateUpdate()
    {
        Rotate();
    }

    public void SetIsRotating(bool value)
    {
        isRotating=value;
    }

    void Rotate()
    {
        //previousMousePos = MousePos;
        if (!isRotating || Time.timeScale <= 0)
            return;
        MousePos = Mouse.current.position.value;
        Vector3 mousePosDelta = MousePos - mouseDefaultPos;
        transform.eulerAngles += new Vector3(0, mousePosDelta.x, 0) * rotationSpeed * Time.deltaTime;
        Mouse.current.WarpCursorPosition(mouseDefaultPos);
        previousMousePos = Mouse.current.position.value;
    }
    public void GetMouseInput(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        previousMousePos = MousePos;
        MousePos = context.ReadValue<Vector2>();
    }
}