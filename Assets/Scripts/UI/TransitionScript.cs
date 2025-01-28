using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] BoolVariable startsHovering;
    [SerializeField] Animator animator;
    [SerializeField] StringVariable sceneName;
    [SerializeField] GameEvent onTransitionFinished;
    private void Start()
    {
        sceneName.Variable = null;
        if (startsHovering.Variable)
        {
            animator.Play("Transition_End");
            startsHovering.Variable = false;
        }
    }

    public void PlayTransition()
    {
        animator.Play("Transition_Start");
    }

    public void PlayEndTransition()
    {
        animator.Play("Transition_End");
    }

    public void TransitionFinished()
    {
        onTransitionFinished.Raise();
    }
}
