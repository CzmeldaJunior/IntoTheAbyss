using UnityEngine;
using UnityEngine.UIElements;

public class WorldItem : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public int amount;

    public virtual string GetInteractionPrompt()
    {
        return "jsem WorldItem";
    }

    private void Awake()
    {
        if (itemData.canSpawnMultiple)
            amount = Random.Range(1, 20);
        else
            amount = 1;
    }
}
