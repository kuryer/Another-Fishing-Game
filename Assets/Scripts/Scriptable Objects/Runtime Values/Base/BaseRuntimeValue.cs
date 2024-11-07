using UnityEngine;

public abstract class BaseRuntimeValue<T> : ScriptableObject where T : class
{
    public T Item;

    public void Set(T item)
    {
        Item = item;
    }

    public void SetNull()
    {
        Item = null;
    }
}

