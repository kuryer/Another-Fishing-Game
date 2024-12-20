using UnityEngine;
using UnityEngine.InputSystem;

public class BobReel : MonoBehaviour
{
    [SerializeField] Transform sourceTransform;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] float reelingSpeed;
    bool isReeling;
    void Start()
    {
        
    }

    void Update()
    {
        if (isReeling)
            ReelBob();
    }

    void ReelBob()
    {
        bobRB.position = bobRB.position + (sourceTransform.position - bobRB.position).normalized * reelingSpeed * Time.deltaTime;
        // tu jeszcze ta normalized pozycja musi miec ustawione y = 0 przed normalizem zeby bob nie lecial do gory
    
    }

    public void ReelBobInput(InputAction.CallbackContext context)
    {
        if(context.performed)
            isReeling = true;
        if(context.canceled)
            isReeling= false;
    }
}
