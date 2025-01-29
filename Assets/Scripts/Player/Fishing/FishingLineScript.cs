using UnityEngine;

public class FishingLineScript : MonoBehaviour
{
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] Transform fishingRodPoint;
    [SerializeField] Transform bobPoint;
    [SerializeField] Vector3 overrideRotation;
    [SerializeField] float scalar;
    [SerializeField] float heightFix;
    [SerializeField] float distanceFix;

    void Update()
    {
        AdjustLine();
    }

    void AdjustLine()
    {
        Vector2 start = new Vector2(fishingRodPoint.position.x, fishingRodPoint.position.z);
        Vector2 end = new Vector2(bobPoint.position.x, bobPoint.position.z);

        float distance = Vector2.Distance(start, end);
        float height = fishingRodPoint.position.y - bobPoint.position.y;

        transform.localScale = new Vector3(distance/scalar, 0.1f, height/scalar);
        transform.localPosition = new Vector3(0, -height/2 + heightFix, distance / 2 - distanceFix);

        transform.LookAt(bobPoint);
        transform.eulerAngles = new Vector3(overrideRotation.x, transform.eulerAngles.y, overrideRotation.z);
    }
}
