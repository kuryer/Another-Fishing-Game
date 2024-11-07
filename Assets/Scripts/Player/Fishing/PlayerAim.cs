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
    [SerializeField] ActivityStateValue actualActivityState;
    [SerializeField] ActivityState aimingActivityState;
    

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
        actualActivityState.Set(aimingActivityState);
    }

    void StopAiming()
    {
        cameraManager.ChangeLiveCamera(defaultCamera);
    }

}
