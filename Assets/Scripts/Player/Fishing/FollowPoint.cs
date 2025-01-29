using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    [SerializeField] Transform followTransform;
    void Update()
    {
        transform.position = followTransform.position;
    }
}
