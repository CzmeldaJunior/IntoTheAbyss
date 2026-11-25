using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, ISelectHandler
{
    public string itemName;
    public int quantity;
    public Sprite icon;

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemIcon;

    [SerializeField]
    private InventoryManager _inventoryManager;

    private Canvas _canvas;

    public CanvasGroup canvasGroup;
    public RectTransform visualRoot;

    private Transform originalParent;

    public int slotIndex;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        _inventoryManager = GetComponentInParent<InventoryManager>();
    }

    public void SetSlot(InventoryItem item)
    {
        if (item == null || item.itemData == null || item.amount <= 0)
        {
            ClearSlot();
            return;
        }

        itemName = item.itemData.itemName;

        quantity = item.amount;

        icon = item.itemData.icon;

        itemIcon.sprite = icon;

        if (itemIcon.sprite != null)
        {
            itemIcon.enabled = true;
        }

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("beginDrag");

        originalParent = visualRoot.parent;

        visualRoot.SetParent(_canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        visualRoot.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DragEnd");
        visualRoot.SetParent(this.transform);

        visualRoot.localPosition = Vector3.zero;

        //Aby bylo navrchu
        visualRoot.SetAsFirstSibling();

        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        InventoryUISlot otherSlot = eventData.pointerDrag.GetComponent<InventoryUISlot>();
        if (otherSlot == null || otherSlot == this) return;

        _inventoryManager.SwapItems(this.slotIndex, otherSlot.slotIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnSelect(BaseEventData eventData)
    {
        
    }
}
