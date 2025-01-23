using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}
