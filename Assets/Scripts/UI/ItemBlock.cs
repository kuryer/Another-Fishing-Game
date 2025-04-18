using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBlock : DescriptionBlock, IPointerClickHandler
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] GameEvent onDescriptionExit;
    [Header("Bait Selection")]
    [SerializeField] GameObject baitHighlightUI;
    [SerializeField] GameEvent onDeactivateBaitHighlights;
    [SerializeField] BaitValue currentBait;
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
        countText.text = count.ToString();
    }

    public void ClearItem()
    {
        if(currentBait.Item == currentItem)
            DeselectBait();
        currentItem = null;
        itemImage.enabled = false;
        onDescriptionExit.Raise();
        countText.text = string.Empty;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right)
            return;

        if(currentItem == currentBait.Item)
        {
            DeselectBait();
            return;
        }
        if (currentItem is Bait)
            SelectBait();
    }

    void SelectBait()
    {
        currentBait.Set((Bait)currentItem);
        onDeactivateBaitHighlights.Raise();
        baitHighlightUI.SetActive(true);
    }

    void DeselectBait()
    {
        currentBait.SetNull();
        baitHighlightUI.SetActive(false);
    }

    public void DeactivateHighlight()
    {
        if(currentBait.Item != currentItem)
            baitHighlightUI.SetActive(false);
    }
}
