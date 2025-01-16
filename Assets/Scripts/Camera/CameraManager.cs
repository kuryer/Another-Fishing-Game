using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase liveCamera;
    [SerializeField] PlayerRotation playerRotation;

    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCameraBase wanderingCamera;
    [SerializeField] CinemachineVirtualCameraBase fishingCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFishingCamera()
    {
        ChangeLiveCamera(fishingCamera);
    }

    public void SetWanderingCamera()
    {
        ChangeLiveCamera(wanderingCamera);
        Debug.Log("Hello?");
    }

    public void ChangeLiveCamera(CinemachineVirtualCameraBase camera)
    {
        camera.enabled = true;
        liveCamera.enabled = false;
        liveCamera = camera;
        //playerRotation.SetCameraReferenceObject(camera.transform);
    }
}
