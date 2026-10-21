using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon currentWeapon;

    public void Fire()
    {
        Debug.Log("Výstřel");
        currentWeapon.Shoot();
    }

    public void Reload()
    {
        Debug.Log("Přebij");
    }
}
