using UnityEngine;

public class TransformCollector : MonoBehaviour
{
    [SerializeField] TransformValue reference;

    private void Awake()
    {
        if(enabled)
            reference.Set(transform);
    }

    private void OnEnable()
    {
        reference.Set(transform);
    }

    private void OnDisable()
    {
        reference.SetNull();
    }
}
