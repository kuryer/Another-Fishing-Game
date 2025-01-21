using System.Collections.Generic;
using UnityEngine;

public class WaterBasin : MonoBehaviour
{
    [SerializeField] List<Fish> catchableFishes;
    [SerializeField] float catchChance;
    public Fish isFishOnReel()
    {
        float catchResult = Random.Range(0f, 100f);
        if(catchResult < catchChance)
            return catchableFishes[Random.Range(0, catchableFishes.Count)];
        return null;
    }
}
