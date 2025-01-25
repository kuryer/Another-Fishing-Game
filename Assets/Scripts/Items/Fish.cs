using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Scriptable Objects/Items/Fish")]
public class Fish : Item
{
    [Header("Drop Chance")]
    public float dropChance;
    [SerializeField] List<Bait> lovedBaits;
    public bool IsCaught(Bait bait)
    {
        float chance = 0;
        if (lovedBaits.Contains(bait))
            chance += bait.baitChance;
        chance += dropChance;
        return chance >= Random.Range(0.0f, 100.0f);
    }

    [Header("Minigame Values")]
    [SerializeField] public Vector2Int blockadesAmount;
    [SerializeField] public Vector2Int blockadesLives;
}
