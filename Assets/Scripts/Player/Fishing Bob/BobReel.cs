using UnityEngine;
using UnityEngine.InputSystem;

public class BobReel : MonoBehaviour
{
    [SerializeField] Transform sourceTransform;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] float reelingSpeed;
    [SerializeField] FishingDetection fishingDetection;
    [SerializeField] string waterTag;
    [Header("State Management")]
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityState wanderingState;
    float minDistance;
    bool isReeling;
    void Start()
    {
        
    }

    void Update()
    {
        if (isReeling)
            ReelBob();
        if(IsInMinDistance())
            TakeOutBob();
    }

    void ReelBob()
    {
        Vector3 direction = (sourceTransform.position - bobRB.position);
        direction.y = 0;
        bobRB.position = bobRB.position + direction.normalized * reelingSpeed * Time.deltaTime;
    }

    bool IsInMinDistance()
    {
        Vector2 bobPos = new Vector2 (bobRB.position.x, bobRB.position.z);
        Vector2 sourcePos = new Vector2(sourceTransform.position.x, sourceTransform.position.z);
        float distance = Vector2.Distance(bobPos, sourcePos);
        return distance <= minDistance;
    }

    void TakeOutBob()
    {
        bobRB.transform.localPosition = new Vector3(0, 1.5f, 0);
        playerStateManager.ChangeState(wanderingState);
        enabled = false;
    }

    public void ReelBobInput(InputAction.CallbackContext context)
    {
        if(context.performed)
            isReeling = true;
        if(context.canceled)
            isReeling= false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            enabled = true;
            minDistance = fishingDetection.GetDistance().x;
        }
    }
}
