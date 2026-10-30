using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;

    public GameObject obj;
    public int amount;

    public InventoryItem(ItemData data, int amount)
    {
        itemData = data;
        this.amount = amount;
    }

    public InventoryItem(GameObject obj, int amount)
    {
        this.obj = obj;
        this.amount = amount;
    }
}
