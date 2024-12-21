using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityStateValue actualActivityState;
    [SerializeField] ActivityState aimingActivityState;
    [SerializeField] ActivityState wanderingActivityState;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AimingAction(InputAction.CallbackContext context)
    {
        if (context.performed) 
            StartAiming();
        if (context.canceled && actualActivityState.Item == aimingActivityState) 
            StopAiming();
    }

    void StartAiming()
    {
        playerStateManager.ChangeState(aimingActivityState);
    }

    void StopAiming()
    {
        playerStateManager.ChangeState(wanderingActivityState);
    }

}
