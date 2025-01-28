using UnityEngine;

public class WaterDrown : MonoBehaviour
{
    [SerializeField] GameEvent onPlayerDrowned;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            onPlayerDrowned.Raise();
    }

}
