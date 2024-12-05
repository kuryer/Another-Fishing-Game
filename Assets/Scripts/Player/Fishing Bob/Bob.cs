using System.Collections;
using UnityEngine;

public class Bob : MonoBehaviour
{
    [SerializeField] AnimationCurve throwTrajectory;
    [SerializeField] float bobSpeed;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] FishingDetection detection;
    [SerializeField] string waterTag;
    Coroutine throwCoroutine;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ThrowBob()
    {
        throwCoroutine = StartCoroutine(BobTravel());
    }

    IEnumerator BobTravel()
    {
        Vector2 distanceInfo = detection.GetDistance();
        float currentDistance = distanceInfo.x;
        float maxDistance = distanceInfo.x + distanceInfo.y;
        while (enabled)
        {
            bobRB.position = bobRB.transform.forward * throwTrajectory.Evaluate(currentDistance / maxDistance);
            currentDistance += bobSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(waterTag))
            StopCoroutine(throwCoroutine);
    }
}
