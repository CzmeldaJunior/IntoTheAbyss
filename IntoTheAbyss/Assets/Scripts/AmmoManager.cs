using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField]
    private InventoryManager _inventoryManager;

    public int lightAmmoCount;
    public int mediumAmmoCount;
    public int HeavyAmmoCount;

    private void OnEnable()
    {
        _inventoryManager.OnInventoryChange += CheckInventoryForAmmo;

        CheckInventoryForAmmo();
    }
    private void OnDisable()
    {
        _inventoryManager.OnInventoryChange -= CheckInventoryForAmmo;
    }

    private void CheckInventoryForAmmo()
    {
        lightAmmoCount = 0;
        mediumAmmoCount = 0;
        HeavyAmmoCount = 0;

        foreach (var slot in _inventoryManager.inventory)
        {
            if (slot.itemData is AmmoData ammoData)
            {
                switch (ammoData.ammoType)
                {
                    case AmmoType.Light:
                        lightAmmoCount += slot.amount;
                        break;

                    case AmmoType.Medium:
                        mediumAmmoCount += slot.amount;
                        break;

                    case AmmoType.Heavy:
                        HeavyAmmoCount += slot.amount;
                        break;
                }
            }

        }
    }

    public int RemoveAmmo(AmmoType ammoType, int count)
    {
        int remainingAmmoToRemove = count;

        foreach (var slot in _inventoryManager.inventory.OrderBy(item => item.amount))
        {
            if (slot.itemData is AmmoData ammoData && ammoData.ammoType == ammoType)
            {
                int amountToRemoveFromSlot = Mathf.Min(slot.amount, remainingAmmoToRemove);

                slot.amount -= amountToRemoveFromSlot;
                remainingAmmoToRemove -= amountToRemoveFromSlot;

                if (remainingAmmoToRemove <= 0)
                    break;
            }
        }

        _inventoryManager.inventory.RemoveAll(item => item.amount <= 0);

        return count - remainingAmmoToRemove;

        //pridat event pointer na inventory manager aby se spravne ukazovali Light/Medium/Heavy counts
    }
}
