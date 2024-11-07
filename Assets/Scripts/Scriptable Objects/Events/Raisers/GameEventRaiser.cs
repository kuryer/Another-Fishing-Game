using UnityEngine;

public class GameEventRaiser : MonoBehaviour
{
    [SerializeField] GameEvent Event;
    public void RaiseEvent()
    {
        Event.Raise();
    }
}
