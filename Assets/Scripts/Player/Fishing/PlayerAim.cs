using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] CameraManager cameraManager;
    [SerializeField] CinemachineVirtualCameraBase fishingCamera;
    [SerializeField] CinemachineVirtualCameraBase defaultCamera;

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
        cameraManager.ChangeLiveCamera(fishingCamera);
        playerStateManager.ChangeState(aimingActivityState);
    }

    void StopAiming()
    {
        cameraManager.ChangeLiveCamera(defaultCamera);
        playerStateManager.ChangeState(wanderingActivityState);
    }

}
