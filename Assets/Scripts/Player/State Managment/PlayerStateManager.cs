using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] ActivityState defaultState;
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

    private void OnDisable()
    {
        actualState.Item = defaultState;
    }

}
