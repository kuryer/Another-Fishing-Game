using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRuntimeList<T> : ScriptableObject
{
    public List<T> List;

    public void Add(T item)
    {
        List.Add(item);
    }

    public void Remove(T item)
    {
        if(List.Contains(item))
            List.Remove(item);
    }

    public void ResetList()
    {
        List = new List<T>();
    }
}