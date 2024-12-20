using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Player/Activity State")]
public class ActivityState : ScriptableObject
{
    [SerializeField] GameEvent OnStartedEvent;
    [SerializeField] GameEvent OnFinishedEvent;

    public void StateStarted()
    {
        OnStartedEvent.Raise();
    }

    public void StateFinished() 
    { 
        OnFinishedEvent.Raise();
    }
}
