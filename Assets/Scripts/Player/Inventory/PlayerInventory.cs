using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    bool inShop;
    [SerializeField] int inventoryCapacity;
    [SerializeField] GameObject inventoryUI;
    Dictionary<Item,int> inventory = new Dictionary<Item,int>();
    [SerializeField] List<ItemBlock> itemBlocks;
    [SerializeField] List<SellItemScript> sellItems;

    [Header("Player's Money")]
    [SerializeField] IntVariable playerMoney;
    [SerializeField] TextMeshProUGUI moneyText;

    [Header("State Management")]
    [SerializeField] ActivityStateValue currentActivity;
    [SerializeField] ActivityState UiActivityState;
    [SerializeField] ActivityState wanderingActivityState;
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] GameEvent onInventoryClosedEvent;

    [Header("Debug bait")]
    [SerializeField] Bait debugBait;

    private void Start()
    {
        UpdateMoney();
        DebugBait();
    }
    void DebugBait()
    {
        AddItem(debugBait);
    }


    public void SetShopActive(bool isActive)
    {
        inShop = isActive;
        SetInventoryActive(isActive);
        foreach (var item in sellItems)
            item.enabled = isActive;
    }

    public bool IsInventoryFull()
    {
        return inventory.Count == inventoryCapacity;
    }

    public void AddItem(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] = ++inventory[item];
            foreach(var block in itemBlocks)
            {
                if (block.GetItem() == item)
                {
                    block.SetCount(inventory[item]);
                    break;
                }
            }
        }
        else
        {
            inventory.Add(item, 1);
            foreach (var block in itemBlocks)
            {
                if (block.IsFree())
                {
                    block.SetItem(item);
                    block.SetCount(inventory[item]);
                    break;
                }
            }
        }
    }

    public void RemoveItem(Item item)
    {
        foreach(var block in itemBlocks)
        {
            if(block.GetItem() == item)
            {
                if (inventory[item] == 1)
                {
                    inventory.Remove(item);
                    block.ClearItem();
                }
                else
                {
                    inventory[item]--;
                    block.SetCount(inventory[item]);
                }
            }
        }
    }

    public void InventoryInput(InputAction.CallbackContext context)
    {
        if (context.performed && !inShop && (currentActivity.Item == wanderingActivityState || inventoryUI.activeInHierarchy))
            SetInventoryActive(!inventoryUI.activeInHierarchy);
    }

    void SetInventoryActive(bool isActive)
    {
        inventoryUI.SetActive(isActive);
        if (isActive)
        {
            playerStateManager.ChangeState(UiActivityState);
        }
        else
        {
            playerStateManager.ChangeState(wanderingActivityState);
            onInventoryClosedEvent.Raise();
        }
    }

    public void UpdateMoney()
    {
        moneyText.text = playerMoney.Variable.ToString();
    }
}
