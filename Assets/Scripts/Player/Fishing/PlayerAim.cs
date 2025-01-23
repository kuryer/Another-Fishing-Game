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
        if (context.performed && actualActivityState.Item == wanderingActivityState) 
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