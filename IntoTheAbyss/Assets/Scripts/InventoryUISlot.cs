using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite icon;

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemIcon;



    public void SetSlot(InventoryItem item)
    {
        if (item == null) return;

        itemName = item.itemData.itemName;

        quantity = item.amount;

        icon = item.itemData.icon;

        itemIcon.sprite = icon;

        if (quantity == 1)
        {
            quantityText.text = string.Empty;
        }
        else
        {
            quantityText.text = quantity.ToString();
        }
        quantityText.enabled = true;
    }

    public void ClearSlot()
    {
        quantity = 0;

        icon = null;

        if (itemIcon != null)
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }

        if (quantityText != null)
        {
            quantityText.text = string.Empty;
            quantityText.enabled = false;
        }
    }

}
