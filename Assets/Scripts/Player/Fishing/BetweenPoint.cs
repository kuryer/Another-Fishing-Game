using UnityEngine;

public class BetweenPoint : MonoBehaviour
{
    [SerializeField] Transform fishingTransform;
    [SerializeField] Transform bobTransform;
    [SerializeField] float distCurvature;
    [SerializeField] float heightCurvature;
    void Update()
    {
        Vector2 start = new Vector2(fishingTransform.position.x, fishingTransform.position.z);
        Vector2 end = new Vector2(bobTransform.position.x, bobTransform.position.z);

        Vector2 distance = Vector2.Lerp(start, end, distCurvature);
        float height = Mathf.Lerp(fishingTransform.position.y, bobTransform.position.y, heightCurvature);

        transform.position = new Vector3(distance.x, height,distance.y);
    }
}
