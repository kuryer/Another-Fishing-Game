using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    bool inRange;
    [SerializeField] List<Item> stockItems;
    [SerializeField] List<ShopBlock> shopBlocks;
    [SerializeField] GameObject shopUI;
    [SerializeField] string playerTag;
    [SerializeField] IntVariable playerMoney;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] ActivityStateValue currentActivity;
    [SerializeField] ActivityState wanderingActivity;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Vector2 pitchRange;
    private void Start()
    {
        InitializeBlocks();
    }

    void InitializeBlocks()
    {
        for (int i = 0; i < stockItems.Count; i++)
        {
            if(i >= shopBlocks.Count)
            {
                Debug.Log("More items than blocks");
                return;
            }
            shopBlocks[i].SetItem(stockItems[i]);
        }
    }

    public void SellItem(Item item)
    {
        playerMoney.Inrease(item.sellPrice);
        playerInventory.RemoveItem(item);
        playerInventory.UpdateMoney();
        PlayAudio();
    }

    public void BuyItem(Item item)
    {
        if (playerInventory.IsInventoryFull())
            return;
        int price = item.buyPrice;
        if (price > playerMoney.Variable)
            return;

        playerMoney.Inrease(-item.buyPrice);
        playerInventory.AddItem(item);
        playerInventory.UpdateMoney();
        PlayAudio();
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

    void PlayAudio()
    {
        float pitch = Random.Range(pitchRange.x, pitchRange.y);
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}
