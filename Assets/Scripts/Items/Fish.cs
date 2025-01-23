using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Scriptable Objects/Items/Fish")]
public class Fish : Item
{
    [Header("Minigame Values")]
    [SerializeField] public Vector2Int blockadesAmount;
    [SerializeField] public Vector2Int blockadesLives;
}
