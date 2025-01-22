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

    [Header("Fish Reeling")]
    WaterBasin currentBasin;
    Fish currentFish;
    [SerializeField] float fishQueryInterval;
    float currentfishQueryTime;

    [Header("Minigame")]
    [SerializeField] GameObject minigameObject;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentFish = null;
    }

    void Update()
    {
        if (currentFish is not null)
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
            currentFish = currentBasin.isFishOnReel();
            if (currentFish == null)
            {
                currentfishQueryTime = fishQueryInterval;
                return;
            }
            else
            {
                //ustaw animacje
                
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

    void TakeOutBob()
    {
        bobRB.transform.localPosition = new Vector3(0, 1.5f, 0);
        playerStateManager.ChangeState(wanderingState);
        enabled = false;
    }

    public void ReelBobInput(InputAction.CallbackContext context)
    {
        if (!enabled)
            return;
        if(currentFish == null)
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
        Debug.Log("Minigame");
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
