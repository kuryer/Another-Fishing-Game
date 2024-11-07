using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Variables/Saved Float Variables")]
public class SavedFloat : ScriptableObject
{
    [SerializeField] public float Value { get; private set; }
    [SerializeField] public string VariableName;

    public void Initialize()
    {
        Value = PlayerPrefs.GetFloat(VariableName);
    }

    public void SetValue(float value)
    {
        Value = value;
        PlayerPrefs.SetFloat(VariableName, Value);
    }
}
