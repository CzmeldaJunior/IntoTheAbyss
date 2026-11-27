using System.Collections.Generic;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    [SerializeField]
    private HotbarUISlot _consumableSlot;
    [SerializeField]
    private HotbarUISlot _trowableSlot;

    [SerializeField]
    private InventoryManager _inventoryManager;

    [SerializeField] private List<InventoryItem> _consumables = new List<InventoryItem>();

    [SerializeField] private List<InventoryItem> _trowable = new List<InventoryItem>();

    private void OnEnable()
    {
        _inventoryManager.OnInventoryChange += FillLists;
        _inventoryManager.OnInventoryChange += UpdateUI;
    }
    private void OnDisable()
    {
        _inventoryManager.OnInventoryChange -= FillLists;
        _inventoryManager.OnInventoryChange -= UpdateUI;
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

    public void UpdateUI()
    {
        _consumableSlot.SetSlot(_consumables[1]);

        _trowableSlot.SetSlot(_trowable[1]);
    }
}
