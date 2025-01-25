using System.Collections.Generic;
using UnityEngine;

public class WaterBasin : MonoBehaviour
{
    [SerializeField] List<Fish> catchableFishes;
    [SerializeField] BaitValue currentBait;
    public Fish isFishOnReel()
    {
        if(currentBait.Item is null)
            return null;

        foreach(var fish in catchableFishes)
        {
            if(fish.IsCaught(currentBait.Item))
                return fish;
        }
        return null;
    }
}
