using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public void AddToInventory(ItemData itemData, int amount)
    {
        InventoryItem existingItem = inventory.Find(item => item.itemData == itemData && item.amount < itemData.stackSize);

        if (existingItem != null)
        {
            int spaceInStack = itemData.stackSize - existingItem.amount;

            int amountToAdd = Mathf.Min(amount, spaceInStack);

            existingItem.amount += amountToAdd;

            amount -= amountToAdd;
        }

        while(amount >= itemData.stackSize)
        {
            inventory.Add(new InventoryItem(itemData, itemData.stackSize));

            amount -= itemData.stackSize;
        }

        if (amount > 0)
        {
            inventory.Add(new InventoryItem(itemData, amount));
        }
    }
    public void AddToInventory(ItemData itemData, int amount, int currentAmmo)
    {
        inventory.Add(new InventoryItem(itemData, 1, currentAmmo));
    }

    public void AddToInventory(GameObject item, int amount)
    {
        inventory.Add(new InventoryItem(item, amount));
    }
}
