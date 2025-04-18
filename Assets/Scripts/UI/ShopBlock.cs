using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopBlock : DescriptionBlock, IPointerClickHandler
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI priceText;

    [SerializeField] ShopScript shopScript;

    public void SetItem(Item item)
    {
        itemImage.enabled = true;
        currentItem = item;
        itemImage.sprite = item.itemSprite;
        priceText.text = item.buyPrice.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
            shopScript.BuyItem(currentItem);
    }
}
