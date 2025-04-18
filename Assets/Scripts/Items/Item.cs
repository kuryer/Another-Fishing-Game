using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite itemSprite;
    public int sellPrice;
    public int buyPrice;
}
