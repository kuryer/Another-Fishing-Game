using System.Collections.Generic;
using UnityEngine;

public abstract class BaseVariableEvent<T> : ScriptableObject
{
    protected T variable;
    public T Variable { get { return variable; } }
    List<VariableEventListener<T>> listeners = new List<VariableEventListener<T>>();

    public abstract void Initialize();

    public abstract void Change(T value);

    public void Subscribe(VariableEventListener<T> eventListener)
    {
        listeners.Add(eventListener);
    } 

    public void Unsubscribe(VariableEventListener<T> eventListener)
    {
        listeners.Remove(eventListener);
    }

    protected void RaiseEvent()
    {
        foreach (var listener in listeners)
            listener.Raise();
    }
}
