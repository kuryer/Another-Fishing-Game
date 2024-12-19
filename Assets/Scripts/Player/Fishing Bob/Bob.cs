using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bob : MonoBehaviour
{
    [SerializeField] AnimationCurve throwTrajectoryX;
    [SerializeField] AnimationCurve throwTrajectoryY;
    [SerializeField] float debugValue;
    [SerializeField] float bobSpeed;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] FishingDetection detection;
    [SerializeField] string waterTag;
    Coroutine throwCoroutine;
    Vector3 throwDirection;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ThrowBob(InputAction.CallbackContext context)
    {
        if(context.performed)
            throwCoroutine = StartCoroutine(BobTravel());
    }

    IEnumerator BobTravel()
    {
        Vector2 distanceInfo = detection.GetDistance();
        float currentDistance = 0;
        float maxDistance = distanceInfo.x + distanceInfo.y;
        throwDirection = bobRB.transform.forward.normalized;
        Vector3 startingPos = bobRB.position;
        Debug.Log("BobTravel");
        while (enabled)
        {
            bobRB.position = startingPos + maxDistance * EvaluateTrajectory(currentDistance / maxDistance);
            currentDistance += bobSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private Vector3 EvaluateTrajectory(float time)
    {
        float x = throwTrajectoryX.Evaluate(time) * throwDirection.x;
        float z = throwTrajectoryX.Evaluate(time) * throwDirection.z;
        float y = throwTrajectoryY.Evaluate(time);
        Debug.Log(time);
        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            Debug.Log("StopCoroutine");
            StopCoroutine(throwCoroutine);  
        }
    }
}
