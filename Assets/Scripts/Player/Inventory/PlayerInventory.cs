using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int inventoryCapacity;
    [SerializeField] GameObject inventoryUI;
    Dictionary<Item,int> inventory = new Dictionary<Item,int>();
    [SerializeField] List<ItemBlock> itemBlocks;
    public bool isInventoryFull()
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

    public void InventoryInput(InputAction.CallbackContext context)
    {
        if (context.performed)
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
    }
}
