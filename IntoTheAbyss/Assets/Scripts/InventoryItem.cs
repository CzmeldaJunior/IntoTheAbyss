using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int amount;

    public InventoryItem(ItemData data, int amount)
    {
        itemData = data;
        this.amount = amount;
    }
}
