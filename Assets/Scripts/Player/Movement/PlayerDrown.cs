using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDrown : MonoBehaviour
{
    [SerializeField] float sphereRadius;
    [SerializeField] Vector3 shpereOffset;
    [SerializeField] string groundTag;
    [SerializeField] string waterTag;
    [SerializeField] float queryInterval;
    [SerializeField] Vector3 lastValidPosition;

    [Header("Drown Pipeline")]
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TransitionScript transition;
    void Start()
    {
        StartCoroutine(GroundCheck());  
    }

    IEnumerator GroundCheck()
    {
        while (enabled)
        {
            if (playerInput.enabled)
            {
                bool isValid = false;
                Collider[] colliders = Physics.OverlapSphere(transform.position + shpereOffset, sphereRadius);
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag(waterTag))
                    {
                        isValid = false;
                        break;
                    }
                    if (collider.CompareTag(groundTag))
                        isValid = true;
                }
                if (isValid)
                    lastValidPosition = rb.position;
            }
            yield return new WaitForSeconds(queryInterval);
        }
    }

    public void PlayerDrowned()
    {
        //rb.isKinematic = true;
        playerInput.enabled = false;
        transition.PlayTransition();
    }

    public void PlayerRespawn()
    {
        transition.PlayEndTransition();
        rb.position = lastValidPosition;
        rb.isKinematic = false;
        playerInput.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + shpereOffset, sphereRadius);
    }
}
