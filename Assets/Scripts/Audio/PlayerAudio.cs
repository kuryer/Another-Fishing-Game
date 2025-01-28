using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] Vector2 pitchRange;
    [SerializeField] AudioSource audioSource;

    public void PlayFootstep()
    {
        float pitch = Random.Range(pitchRange.x, pitchRange.y);
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}
