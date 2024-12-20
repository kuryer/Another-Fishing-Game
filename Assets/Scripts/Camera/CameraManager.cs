using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase liveCamera;
    [SerializeField] PlayerRotation playerRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLiveCamera(CinemachineVirtualCameraBase camera)
    {
        camera.enabled = true;
        liveCamera.enabled = false;
        liveCamera = camera;
        //playerRotation.SetCameraReferenceObject(camera.transform);
    }
}
