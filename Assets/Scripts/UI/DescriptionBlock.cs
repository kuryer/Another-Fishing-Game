using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionBlock : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] StringEvent OnBlockEnterEvent;
    [SerializeField] GameEvent OnBlockExitEvent;
    [SerializeField] protected Item currentItem = null;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem is null)
            return;
        Debug.Log("Enter");
        OnBlockEnterEvent.Change(currentItem.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(currentItem is null)
            return;
        Debug.Log("Exit");
        OnBlockExitEvent.Raise();
    }
}
