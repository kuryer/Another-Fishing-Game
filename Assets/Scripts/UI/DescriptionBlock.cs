using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionBlock : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] StringEvent OnBlockEnterEvent;
    [SerializeField] StringEvent OnItemNameSetEvent;
    [SerializeField] GameEvent OnBlockExitEvent;
    [SerializeField] protected Item currentItem = null;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem is null)
            return;

        OnItemNameSetEvent.Change(currentItem.name);
        OnBlockEnterEvent.Change(currentItem.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(currentItem is null)
            return;

        OnBlockExitEvent.Raise();
    }
}
