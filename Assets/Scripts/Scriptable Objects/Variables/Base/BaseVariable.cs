using UnityEngine;

public abstract class BaseVariable<T> : ScriptableObject
{
    public T Variable;

    [SerializeField] T DefaultValue;

    public void SetToDefault()
    {
        Variable = DefaultValue;
    }
}
