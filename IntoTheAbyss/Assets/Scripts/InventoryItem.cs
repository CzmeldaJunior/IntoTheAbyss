using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int amount;

    //[NonSerialized]
    public int currentAmmo;

    //Basic loot
    public InventoryItem(ItemData data, int amount)
    {
        itemData = data;
        this.amount = amount;
    }
    //Weapons
    public InventoryItem(ItemData data, int amount, int currentAmmo /*attachmenty*/)
    {
        itemData = data;
        this.amount = amount;
        this.currentAmmo = currentAmmo;
    }
}
