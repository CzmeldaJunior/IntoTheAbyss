using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInput : MonoBehaviour
{
    [SerializeField]
    private WeaponController _weaponController;

    public void OnFire(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            _weaponController.Fire();
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _weaponController.Reload();
        }
        
    }

}
