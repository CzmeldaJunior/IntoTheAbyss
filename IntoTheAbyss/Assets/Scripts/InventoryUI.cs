using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _Backpack;

    [SerializeField]
    private InventoryUISlot _UIslot;

    [SerializeField]
    private GameObject _UISlotContainer;

    [SerializeField]
    private InventoryManager _inventoryManager;

    [SerializeField]
    private List<InventoryUISlot> _inventoryUIslots = new List<InventoryUISlot>();

    private void Awake()
    {
        InitializateSlots();

    }

    private void OnEnable()
    {
        UpdateUI();

        _inventoryManager.OnInventoryChange += UpdateUI;
    }

    private void OnDisable()
    {
        _inventoryManager.OnInventoryChange -= UpdateUI;
    }

    private void InitializateSlots()
    {
        _inventoryUIslots.Clear();

        for (int i = 0; i < _inventoryManager.inventorySize; i++)
        {
            InventoryUISlot createdSlot = Instantiate(_UIslot, _UISlotContainer.transform);
            createdSlot.slotIndex = i;
            _inventoryUIslots.Add(createdSlot);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _inventoryUIslots.Count; i++)
        {
            if (i < _inventoryManager.inventory.Count)
            {
                _inventoryUIslots[i].SetSlot(_inventoryManager.inventory[i]);
            }
            else
            {
                _inventoryUIslots[i].ClearSlot();
            }
            
        }
    }

    public void ToggleInventory(bool isOpened)
    {
        _Backpack.SetActive(isOpened);
    }
}
