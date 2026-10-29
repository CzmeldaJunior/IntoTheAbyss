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

    public virtual void Interact(InteractionManager interactor)
    {
        //nebude implementovano
    }

    private void Awake()
    {
        if (itemData.canSpawnMultiple)
            amount = Random.Range(1, 30);
        else
            amount = 1;
    }
}
