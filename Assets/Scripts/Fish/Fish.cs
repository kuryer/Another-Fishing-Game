using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Scriptable Objects/Fish")]
public class Fish : ScriptableObject
{
    [SerializeField] public string fishName;
    [Header("Minigame Values")]
    [SerializeField] public Vector2Int blockadesAmount;
    [SerializeField] public Vector2Int blockadesLives;
}
