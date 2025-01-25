using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BobThrow : MonoBehaviour
{
    [SerializeField] Transform throwStartingPos;
    [SerializeField] AnimationCurve throwTrajectoryX;
    [SerializeField] AnimationCurve throwTrajectoryY;
    [SerializeField] float bobSpeed;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] FishingDetection detection;
    [SerializeField] string waterTag;
    [SerializeField] Transform directionReference;
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityStateValue currentActivity;
    [SerializeField] ActivityState aimingState;
    [SerializeField] ActivityState fishingState;
    [SerializeField] BobReel reelScript;
    [SerializeField] PlayerAnimation playerAnimation;
    bool isThrowing;
    Coroutine throwCoroutine;
    Vector3 throwDirection;
    [Header("Throw Distance")]
    bool isHolding;
    [SerializeField] float maxThrowTime;
    float throwTime;
    [Header("Activate References")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Collider bobCollider;

    void Start()
    {
        
    }

    void Update()
    {
        ThrowTimer();
    }

    void ThrowTimer()
    {
        if (!isHolding)
            return;
        Debug.Log(throwTime);
        throwTime += Time.deltaTime;
        if (throwTime >= maxThrowTime)
            Throw();
    }

    public void ThrowBob(InputAction.CallbackContext context)
    {
        if (context.performed && !isThrowing && currentActivity.Item == aimingState && detection.CanThrow())
        {
            isHolding = true;
            enabled = true;
            throwTime = 0.01f;
        }
        if (isHolding && context.canceled)
            Throw();
    }

    void Throw()
    {
        isHolding = false;
        playerAnimation.PlayAnimation("rod_cast");
        playerStateManager.ChangeState(fishingState);
        isThrowing = true;
    }

    public void Activate()
    {
        meshRenderer.enabled = true;
        bobCollider.enabled = true;
        enabled = true;
        throwCoroutine = StartCoroutine(BobTravel());
    }

    public void Deactivate()
    {
        meshRenderer.enabled = false;
        bobCollider.enabled = false;
        enabled = false;
    }

    IEnumerator BobTravel()
    {
        Vector2 distanceInfo = detection.GetDistance();
        float currentDistance = 0;
        float distance = distanceInfo.x + distanceInfo.y * (throwTime/maxThrowTime);
        throwDirection = directionReference.forward.normalized;
        Vector3 startingPos = throwStartingPos.position;
        while (enabled)
        {
            bobRB.position = startingPos + distance * EvaluateTrajectory(currentDistance / distance);
            currentDistance += bobSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private Vector3 EvaluateTrajectory(float time)
    {
        float x = throwTrajectoryX.Evaluate(time) * throwDirection.x;
        float z = throwTrajectoryX.Evaluate(time) * throwDirection.z;
        float y = throwTrajectoryY.Evaluate(time);
        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            StopCoroutine(throwCoroutine);
            reelScript.enabled = true;
            enabled = false;
        }
    }

    private void OnDisable()
    {
        isThrowing = false;
    }
}
