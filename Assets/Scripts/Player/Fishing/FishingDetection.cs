using UnityEngine;

public class FishingDetection : MonoBehaviour
{
    [SerializeField] private int raysCount;
    [SerializeField] private float rayLength;
    [SerializeField] private float rayStartingDistance;
    [SerializeField] private float rayStepDistance;
    [SerializeField] private Vector3 rayDirection;
    [SerializeField] private string waterDetectionTag;
    private bool[] detections;
    void Start()
    {
        detections = new bool[raysCount];
    }

    // Update is called once per frame
    void Update()
    {
        ThrowCast();
    }

    bool ThrowCast()
    {
        bool result = false;
        for (int i = 0; i < raysCount; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + (transform.forward * rayStartingDistance) + (transform.forward * rayStepDistance * i),
                rayDirection, out hit, rayLength);
            if (hit.collider is null)
                detections[i] = false;
            else
                detections[i] = hit.collider.CompareTag(waterDetectionTag);


            if (detections[i]) result = true;
        }
        return result;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < raysCount; i++)
        {
            Gizmos.color = Application.isPlaying && detections[i] ? Color.red : Color.white;
            Gizmos.DrawRay(transform.position + (transform.forward * rayStartingDistance) + (transform.forward * rayStepDistance * i),
                rayDirection * rayLength);
        }
    }

    public bool CanThrow()
    {
        for(int i = 0; i < raysCount; i++)
        {
            if (detections[i])
                return true;
        }
        return false;
    }

    /// <summary>
    /// Method <c>GetDistance</c> returns the starting position and the throw distance inside a Vector2.
    /// </summary>
    public Vector2 GetDistance()
    {
        int first = -1;
        int last = 0;
        for(int i = 0; i < raysCount; i++)
        {
            if (detections[i] && first == -1)
                first = i;
            if (!detections[i] && first != -1 && i > first)
            {
                last = i - 1;
                break;
            }
            if (i + 1 == raysCount && detections[i])
                last = i;
        }
        float minDistance = rayStartingDistance + rayStepDistance * first;
        float maxDistance = rayStartingDistance + rayStepDistance * last;
        float distance = maxDistance - minDistance;
        //Debug.Log("Max:" + maxDistance + ", min: " + minDistance + ", distance: " + distance);
        //Debug.Log("first:" + first + ", last: " + last);
        return new Vector2(minDistance, distance);
    }
}
