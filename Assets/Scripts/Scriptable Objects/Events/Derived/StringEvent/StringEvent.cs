using UnityEngine;

[CreateAssetMenu(fileName = "StringEvent", menuName = "Scriptable Objects/Utilities/Events/String Event")]
public class StringEvent : BaseVariableEvent<string>
{
    public override void Change(string value)
    {
        variable = value;
        RaiseEvent();
    }

    public override void Initialize()
    {
    }
}
