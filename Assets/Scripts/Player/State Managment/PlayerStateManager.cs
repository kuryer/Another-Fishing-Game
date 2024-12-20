using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] ActivityStateValue actualState;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeState(ActivityState newState)
    {
        actualState.Item.StateFinished();
        actualState.Item = newState;
        actualState.Item.StateStarted();
    }

}
