using UnityEngine;
using UnityEngine.EventSystems;

public class SellItemScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ItemBlock itemBlock;
    [SerializeField] ShopScript shopScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemBlock.GetItem() == null || eventData.button != PointerEventData.InputButton.Left)
            return;
        shopScript.SellItem(itemBlock.GetItem());
    }
}