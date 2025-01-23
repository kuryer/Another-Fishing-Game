using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [Header("Rotation Parameters")]
    [SerializeField] float rotationSpeed;
    Vector2 MousePos;
    Vector2 previousMousePos;

    [Header("Animation Rotation")]
    bool isAnimating;
    float naturalRotation;

    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        previousMousePos = MousePos;
        MousePos = Input.mousePosition;
        Vector3 mousePosDelta = MousePos - previousMousePos;
        transform.eulerAngles += new Vector3(0, mousePosDelta.x, 0);
    }
    public void GetMouseInput(InputAction.CallbackContext context)
    {
        if (!context.performed || !enabled)
            return;
        previousMousePos = MousePos;
        MousePos = context.ReadValue<Vector2>();
    }
}