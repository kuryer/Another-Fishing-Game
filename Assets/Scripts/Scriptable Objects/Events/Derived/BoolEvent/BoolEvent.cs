using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Utilities/Events/Bool Event")]
public class BoolEvent : BaseVariableEvent<bool>
{
    public override void Change(bool value)
    {
        variable = value;
    }

    public override void Initialize()
    {
        variable = false;
    }

    public void Raise()
    {
        RaiseEvent();
    }
}
