using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFishShowcase : MonoBehaviour
{
    [SerializeField] Transform showcaseCamera;
    [SerializeField] GameObject playerModel;
    [SerializeField] float rotationTime;
    bool isShowcasing;
    [Header("State Management")]
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityState wanderingState;
    void Start()
    {
        
    }

    public void Rotate(bool towardsCamera)
    {
        if (towardsCamera)
            StartCoroutine(Rotation(new Vector3(0,180,0), new Vector3(0, 0, 0)));
        else
            StartCoroutine(Rotation(new Vector3(0, 0, 0), new Vector3(0, 180, 0)));
    }

    IEnumerator Rotation(Vector3 start, Vector3 dest)
    {
        float elapsedTime = 0f;
        while(elapsedTime < rotationTime)
        {
            playerModel.transform.localEulerAngles = Vector3.Lerp(start, dest, elapsedTime/rotationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerModel.transform.localEulerAngles = dest;
        isShowcasing = true;
    }


    public void MouseInput(InputAction.CallbackContext context)
    {
        if (isShowcasing && context.performed)
            AddToEquipment();
    }

    void AddToEquipment()
    {
        isShowcasing = false;
        Rotate(false);
        playerStateManager.ChangeState(wanderingState);
    }
}
