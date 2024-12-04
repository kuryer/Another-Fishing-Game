using UnityEngine;

public class FishingDetection : MonoBehaviour
{
    [SerializeField] private int raysCount;
    [SerializeField] private float rayLength;
    [SerializeField] private float rayStartingDistance;
    [SerializeField] private float rayStepDistance;
    [SerializeField] private Vector3 rayDirection;
    [SerializeField] private LayerMask waterLayer;
    private bool[] detections;
    void Start()
    {
        detections = new bool[raysCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowCast()
    {
        for (int i = 0; i < raysCount; i++)
            detections[i] = Physics.Raycast(transform.position + transform.forward * rayStartingDistance + (transform.forward * rayStepDistance * i),
                rayDirection, rayLength, waterLayer);
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < raysCount; i++)
        {
            Gizmos.DrawRay(transform.position + transform.forward * rayStartingDistance + (transform.forward * rayStepDistance * i),
                rayDirection * rayLength);
            //Gizmos.color = detections != null && detections[i] ? Color.red : Color.white;
        }
    }
}
