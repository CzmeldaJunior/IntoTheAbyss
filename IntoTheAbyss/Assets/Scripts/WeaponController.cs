using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<Weapon> _weapons;
    public Weapon currentWeapon;

    public void Fire()
    {
        currentWeapon.Shoot();
    }

    public void Reload()
    {
        currentWeapon.Reload();
    }
    public void SwitchWeapon()
    {
        int index = _weapons.IndexOf(currentWeapon);
        index = 1 - index;
        SelectWeapon(index);
    }

    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>(true).ToList();
    }

    private void Start()
    {
        SelectWeapon(0);
    }

    private void SelectWeapon(int index)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = _weapons[index];
        currentWeapon.gameObject.SetActive(true);
    }
}
