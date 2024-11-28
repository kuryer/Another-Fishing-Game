using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationScript : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] Transform cameraRotationObject;
    [SerializeField] Vector2 rotationRange;
    Vector2 mouseInput;
    Vector2 previousInput;
    Vector3 rotate;
    Resolution resolution;

    void Start()
    {
        resolution = Screen.currentResolution;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Debug.Log(Input.mousePositionDelta);
        //Vector2 rotationMovementDelta = previousInput - mouseInput;
        //Debug.Log(rotationMovementDelta);
        cameraRotationObject.rotation = Quaternion.Euler(new Vector3(mouseInput.y * sensitivity, mouseInput.x, 0f));
    }

    public void GetMouseInput(InputAction.CallbackContext context)
    {
        
        //previousInput = mouseInput;
        mouseInput = context.ReadValue<Vector2>();
        Debug.Log("previous: " + previousInput + ", present: " + mouseInput);
    }

    Vector2 GetRotationScale()
    {
        return new Vector2(mouseInput.x / resolution.width, mouseInput.y / resolution.height);
    }
}
