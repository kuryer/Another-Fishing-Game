using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : EventListener
{
    [SerializeField] UnityEvent Response;

    public override void OnEventRaised()
    {
        Response.Invoke();
    }
}
