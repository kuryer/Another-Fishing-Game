using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BobReel : MonoBehaviour
{
    [SerializeField] Transform sourceTransform;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] float reelingSpeed;
    [SerializeField] FishingDetection fishingDetection;
    [SerializeField] string waterTag;
    float minDistance;
    bool isReeling;
    [Header("State Management")]
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityState wanderingState;
    [SerializeField] ActivityState showcaseState;

    [Header("Fish Reeling")]
    WaterBasin currentBasin;
    [SerializeField] FishValue currentFish;
    [SerializeField] float fishQueryInterval;
    float currentfishQueryTime;

    [Header("Minigame")]
    [SerializeField] GameObject minigameObject;

    [Header("Take Out")]
    [SerializeField] Transform takeOutDestination;
    [SerializeField] float takeOutSpeed;
    Vector3 takeOutDirection; 
    [SerializeField] AnimationCurve takeOutTrajectoryX;
    [SerializeField] AnimationCurve takeOutTrajectoryY;

    [Header("Showcase")]
    [SerializeField] PlayerFishShowcase fishShowcase;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentFish.SetNull();
        isReeling = false;
    }

    void Update()
    {
        if (currentFish.Item is not null)
            return;

        QueryFish();

        if (isReeling)
            ReelBob();
        if(IsInMinDistance())
            TakeOutBob();
    }

    void QueryFish()
    {
        if (currentfishQueryTime <= 0)
        {
            currentFish.Item = currentBasin.isFishOnReel();
            if (currentFish.Item == null)
            {
                currentfishQueryTime = fishQueryInterval;
                return;
            }
            else
            {
                //ustaw animacje ci¹gn¹cej ryby
            }

        }
        currentfishQueryTime -= Time.deltaTime;
    }


    void ReelBob()
    {
        Vector3 direction = (sourceTransform.position - bobRB.position);
        direction.y = 0;
        bobRB.position = bobRB.position + direction.normalized * reelingSpeed * Time.deltaTime;
    }

    bool IsInMinDistance() //on tu musi zapamietywaæ jak¹œ pozycje i w relacji do zapamietywanej pozycji
    {
        Vector2 bobPos = new Vector2 (bobRB.position.x, bobRB.position.z);
        Vector2 sourcePos = new Vector2(sourceTransform.position.x, sourceTransform.position.z);
        float distance = Vector2.Distance(bobPos, sourcePos);
        return distance <= minDistance;
    }

    public void TakeOutBob()
    {
        StartCoroutine(TakeOutAnimation());
    }

    IEnumerator TakeOutAnimation()
    {
        Vector3 startingPos = bobRB.position;
        float distance = Vector3.Distance(startingPos, takeOutDestination.position);
        Debug.Log(distance);
        float currentDistance = 0;
        takeOutDirection = takeOutDestination.forward.normalized;
        while (currentDistance < distance)
        {
            bobRB.position = startingPos + distance * EvaluateTrajectory(currentDistance / distance);
            currentDistance += takeOutSpeed * Time.deltaTime;
            Debug.Log(currentDistance);
            yield return null;
        }
        gameObject.SetActive(false);
        SetProperState();
        enabled = false;
    }

    void SetProperState()
    {
        if(currentFish.Item is null)
            playerStateManager.ChangeState(wanderingState);
        else
        {
            playerStateManager.ChangeState(showcaseState);
            fishShowcase.Rotate(true);
        }
    }

    private Vector3 EvaluateTrajectory(float time)
    {
        float x = takeOutTrajectoryX.Evaluate(time) * -takeOutDirection.x;
        float z = takeOutTrajectoryX.Evaluate(time) * -takeOutDirection.z;
        float y = takeOutTrajectoryY.Evaluate(time);
        return new Vector3(x, y, z);
    }

    public void ReelBobInput(InputAction.CallbackContext context)
    {
        if (!enabled)
            return;
        if(currentFish.Item == null)
        {
            if (context.performed)
                isReeling = true;
            if (context.canceled)
                isReeling = false;
        }
        else
        {
            if (context.started)
                startMinigame();
        }

    }

    void startMinigame()
    {
        minigameObject.SetActive(true);
        enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            minDistance = fishingDetection.GetDistance().x;
            currentBasin = other.GetComponent<WaterBasin>();
            enabled = true;
        }
    }
}
