using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Scriptable Objects/Fish")]
public class Fish : ScriptableObject
{
    [SerializeField] string fishName;
}
