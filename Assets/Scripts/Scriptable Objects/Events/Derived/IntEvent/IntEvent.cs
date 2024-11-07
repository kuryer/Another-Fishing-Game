using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Utilities/Events/Int Event")]
public class IntEvent : BaseVariableEvent<int>
{
    public override void Initialize()
    {
        variable = 0;
    }
    public  void Add(int value)
    {
        variable += value;
    }
    public override void Change(int value)
    {
        variable += value;
        RaiseEvent();
    }
}