using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _inventoryMenu;

    [SerializeField]
    private GameObject _UIslot;

    [SerializeField]
    private GameObject _UISlotContainer;

    [SerializeField]
    private InventoryManager _inventoryManager;

    [SerializeField]
    private List<InventoryUISlot> _inventoryUIslots = new List<InventoryUISlot>();

    private void Awake()
    {
        InitializateSlots();

        _inventoryUIslots.Clear();

        var slots = GetComponentsInChildren<InventoryUISlot>();

        foreach(var slot in slots)
        {
            _inventoryUIslots.Add(slot);
        }
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
        for (int i = 0; i < _inventoryManager.inventorySize; i++)
        {
            Instantiate(_UIslot, _UISlotContainer.transform);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _inventoryManager.inventory.Count; i++)
        {
            _inventoryUIslots[i].SetSlot(_inventoryManager.inventory[i]);
        }
    }

    public void ToggleInventory(bool isOpened)
    {
        _inventoryMenu.SetActive(isOpened);
    }
}
