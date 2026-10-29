using UnityEngine;

public enum AmmoType
{
    Light,
    Medium,
    Heavy
}

[CreateAssetMenu(fileName = "AmmoData", menuName = "Scriptable Objects/AmmoData")]
public class AmmoData : ItemData
{
    public AmmoType ammoType;
}
