using System.Collections.Generic;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _consumableSlot;
    [SerializeField]
    private GameObject _trowableSlot;

    [SerializeField]
    private InventoryManager _inventoryManager;

    [SerializeField] private List<InventoryItem> _consumables = new List<InventoryItem>();

    [SerializeField] private List<InventoryItem> _trowable = new List<InventoryItem>();

    private void OnEnable()
    {
        _inventoryManager.OnInventoryChange += FillLists;
    }
    private void OnDisable()
    {
        _inventoryManager.OnInventoryChange -= FillLists;
    }

    private void FillLists()
    {
        _consumables.Clear();
        _trowable.Clear();

        foreach(var slot in _inventoryManager.inventory)
        {
            if (slot == null || slot.itemData == null || slot.amount <= 0) continue;

            if (slot.itemData.itemType == ItemType.Consumable)
            {
                _consumables.Add(slot);
            }
            else if (slot.itemData.itemType == ItemType.Trowable)
            {
                _trowable.Add(slot);
            }
        }
    }

    private void SetSlots()
    {

    }
}
