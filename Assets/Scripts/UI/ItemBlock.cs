using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBlock : MonoBehaviour
{
    [SerializeField] Item currentItem = null;
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI countText;

    public bool IsFree()
    {
        return currentItem == null;
    }

    public Item GetItem()
    {
        return currentItem;
    }

    public void SetItem(Item item)
    {
        itemImage.enabled = true;
        currentItem = item;
        itemImage.sprite = item.itemSprite;
    }

    public void SetCount(int count)
    {
        Debug.Log("Set Count: " + count);
        countText.text = count.ToString();
    }

    public void ClearItem()
    {
        currentItem = null;
        itemImage.enabled = false;
    }
}
