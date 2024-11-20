using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationScript : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] Transform cameraRotationObject;
    [SerializeField] Vector2 rotationRange;
    Vector2 mouseInput;
    Vector3 rotate;
    Resolution resolution;

    void Start()
    {
        resolution = Screen.currentResolution;
    }

    void Update()
    {

        rotate = new Vector3(mouseInput.y * sensitivity, mouseInput.x, 0f);
        Debug.Log(rotate);
        cameraRotationObject.eulerAngles = rotate;
    }

    public void GetMouseInput(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }

    Vector2 GetRotationScale()
    {
        return new Vector2(mouseInput.x / resolution.width, mouseInput.y / resolution.height);
    }
}
