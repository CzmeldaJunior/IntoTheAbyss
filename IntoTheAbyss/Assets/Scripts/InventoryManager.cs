using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public int inventorySize = 5;

    public event Action OnInventoryChange;

    public int AddToInventory(ItemData itemData, int amount)
    {
        InventoryItem existingItem = inventory.Find(item => item.itemData == itemData && item.amount < itemData.stackSize);

        if (existingItem != null)
        {
            int spaceInStack = itemData.stackSize - existingItem.amount;

            int amountToAdd = Mathf.Min(amount, spaceInStack);

            existingItem.amount += amountToAdd;

            amount -= amountToAdd;
        }

        while (amount >= itemData.stackSize && inventory.Count < inventorySize)
        {
            inventory.Add(new InventoryItem(itemData, itemData.stackSize));

            amount -= itemData.stackSize;
        }

        if (amount > 0 && inventory.Count < inventorySize)
        {
            inventory.Add(new InventoryItem(itemData, amount));

            amount = 0;
        }

        OnInventoryChange?.Invoke();
        return amount;
    }
    public int AddToInventory(ItemData itemData, int amount, int currentAmmo)
    {
        if (inventory.Count >= inventorySize) return amount;

        inventory.Add(new InventoryItem(itemData, 1, currentAmmo));

        OnInventoryChange?.Invoke();
        return 0;
    }
    public int AddToInventory(AmmoData ammoData, int amount)
    {
        InventoryItem existingItem = inventory.Find(item => item.itemData == ammoData && item.amount < ammoData.stackSize);

        if (existingItem != null)
        {
            int spaceInStack = ammoData.stackSize - existingItem.amount;

            int amountToAdd = Mathf.Min(amount, spaceInStack);

            existingItem.amount += amountToAdd;

            amount -= amountToAdd;
        }

        while (amount >= ammoData.stackSize && inventory.Count < inventorySize)
        {
            inventory.Add(new InventoryItem(ammoData, ammoData.stackSize));

            amount -= ammoData.stackSize;
        }

        if (amount > 0 && inventory.Count < inventorySize)
        {
            inventory.Add(new InventoryItem(ammoData, amount));

            amount = 0;
        }

        OnInventoryChange?.Invoke();
        return amount;
    }
}
