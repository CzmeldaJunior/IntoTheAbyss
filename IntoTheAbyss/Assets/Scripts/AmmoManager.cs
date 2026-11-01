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
}
