using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInput : MonoBehaviour
{
    [SerializeField]
    private WeaponController _weaponController;

    bool _isFiring;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isFiring = true;
        }
        if (context.canceled)
        {
            _isFiring = false;
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _weaponController.Reload();
        }

    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _weaponController.SwitchWeapon();
        }
    }

    private void Update()
    {
        if (_isFiring)
        {
            _weaponController.Fire();
        }
    }

}
