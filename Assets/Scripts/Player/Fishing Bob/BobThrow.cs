using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BobThrow : MonoBehaviour
{
    [SerializeField] AnimationCurve throwTrajectoryX;
    [SerializeField] AnimationCurve throwTrajectoryY;
    [SerializeField] float debugValue;
    [SerializeField] float bobSpeed;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] FishingDetection detection;
    [SerializeField] string waterTag;
    [SerializeField] Transform directionReference;
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityState fishingState;
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
        if (context.performed && enabled)
        {
            transform.position = directionReference.position + new Vector3(0,5f,0);
            playerStateManager.ChangeState(fishingState);
            throwCoroutine = StartCoroutine(BobTravel());
        }
    }

    IEnumerator BobTravel()
    {
        Vector2 distanceInfo = detection.GetDistance();
        float currentDistance = 0;
        float maxDistance = distanceInfo.x + distanceInfo.y;
        throwDirection = directionReference.forward.normalized;
        Vector3 startingPos = bobRB.position;
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
        float y = throwTrajectoryY.Evaluate(time) * debugValue;
        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            StopCoroutine(throwCoroutine);
            enabled = false;
        }
    }
}
