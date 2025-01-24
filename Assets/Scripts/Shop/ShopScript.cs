using UnityEngine;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    bool inRange;
    [SerializeField] GameObject shopUI;
    [SerializeField] string playerTag;
    [SerializeField] IntVariable playerMoney;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] ActivityStateValue currentActivity;
    [SerializeField] ActivityState wanderingActivity;
    public void SellItem(Item item)
    {
        playerMoney.Inrease(item.sellPrice);
        playerInventory.RemoveItem(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
            inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
            inRange = false;
    }

    public void GatherShopInput(InputAction.CallbackContext context)
    {
        if (context.performed && inRange && (currentActivity.Item == wanderingActivity || shopUI.activeInHierarchy))
        {
            bool isOpened = shopUI.activeInHierarchy;
            shopUI.SetActive(!isOpened);
            playerInventory.SetShopActive(!isOpened);
            return;
        }
    }
}
