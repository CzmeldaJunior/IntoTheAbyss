using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;

    public float damage;
    public float reloadTime;
    public float fireRate;
    public int magazineSize;
    public float range;
    [Range(0f, 1f)]
    public float spread;


}
