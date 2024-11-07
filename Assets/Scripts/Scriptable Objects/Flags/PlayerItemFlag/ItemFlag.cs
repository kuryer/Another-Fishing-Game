using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Utilities/Flags/Item Flag")]
public class ItemFlag : ScriptableObject
{
    [SerializeField] private bool Value;
    
    public void SetFlag(bool value)
    {
        Value = value;
    }
    public bool GetFlag()
    {
        return Value;
    }

    public void SetToDefault()
    {
        Value = false;
    }
}