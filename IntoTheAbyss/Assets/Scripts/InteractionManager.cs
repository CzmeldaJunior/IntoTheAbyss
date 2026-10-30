using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private float _radius;

    [SerializeField]
    private InventoryManager _inventoryManager;

    public LayerMask interactionLayer;

    private WorldItem _target;

    public void TryInteract()
    {
        if (_target == null) return;

        if (_target.itemData.itemType == ItemType.Weapon)
        {
            _inventoryManager.AddToInventory(_target.gameObject, _target.amount);
            Debug.Log("Sebrani zbrane");
        }
        else
        {
            _inventoryManager.AddToInventory(_target.itemData, _target.amount);
        }
        

        Destroy(_target.gameObject);
    }

    private void FindInteractable()
    {
        Vector3 center = transform.position;

        Collider[] found = Physics.OverlapSphere(center, _radius, interactionLayer);

        WorldItem closestItem = null;
        float bestDistance = _radius;

        foreach(var item in found)
        {
            if(item.TryGetComponent<WorldItem>(out var wItem))
            {
                float distance = Vector3.Distance(item.transform.position, center);

                if (distance < bestDistance)
                {
                    bestDistance = distance;

                    closestItem = wItem;
                }
            }
        }

        _target = closestItem;

        if (closestItem != null)
        {
            Debug.Log(closestItem.gameObject);
        }
    }

    private void Update()
    {
        FindInteractable();
    }
}
