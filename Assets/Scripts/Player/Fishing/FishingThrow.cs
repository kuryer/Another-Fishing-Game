using System.Collections;
using UnityEngine;

public class FishingThrow : MonoBehaviour
{
    [SerializeField] AnimationCurve throwTrajectoryX;
    [SerializeField] AnimationCurve throwTrajectoryY;
    [SerializeField] float bobSpeed;
    [SerializeField] Rigidbody bobRB;
    [SerializeField] FishingDetection detection;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ThrowBob()
    {
        StartCoroutine(BobTravel());
    }

    IEnumerator BobTravel()
    {
        Vector2 distanceInfo = detection.GetDistance();
        float currentDistance = distanceInfo.x;
        float maxDistance = distanceInfo.x + distanceInfo.y;
        //tu jeszcze trzeba popracowaæ troszku
        while (enabled)
        {
            bobRB.position = bobRB.transform.forward * throwTrajectoryX.Evaluate(currentDistance/maxDistance);
            currentDistance += bobSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
