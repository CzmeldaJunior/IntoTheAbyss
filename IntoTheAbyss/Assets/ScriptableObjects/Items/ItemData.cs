using UnityEngine;


public enum ItemType
{
    Consumable,
    Weapon,
    Material,
    Ammo,
    Attachment
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemId;
    public string itemName;

    [TextArea]
    public string description;

    public Sprite icon;
    public GameObject prefab;

    public int stackSize = 1;

    public ItemType itemType;

    public bool canSpawnMultiple;
}
