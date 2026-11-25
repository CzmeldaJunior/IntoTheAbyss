using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IDamageable
{
    private CharacterController _characterController;
    private UnityEngine.InputSystem.PlayerInput _inputSystemPlayerInput;
    [SerializeField]
    private InventoryUI _inventoryUI;
    private Camera _mainCamera;
    [SerializeField]
    private InteractionManager _interactionManager;

    public float hp = 100f;

    private bool _isGamepad = false;

    [SerializeField]
    private float _speed;

    private Vector2 _moveInput;
    private Vector2 _lookInput;

    /*---InventoryInput---*/

    private bool menuOpened;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputSystemPlayerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        _mainCamera = Camera.main;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();

        if (context.control.device is Gamepad)
        {
            _isGamepad = true;
        }
        else if (context.control.device is Keyboard)
        {
            _isGamepad = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactionManager.TryInteract();
        }
    }

    public void OnToggleInventory(InputAction.CallbackContext context)
    {
        
        if(context.performed && menuOpened)
        {
            _inventoryUI.ToggleInventory(false);
            menuOpened = false;
            _inputSystemPlayerInput.SwitchCurrentActionMap("Gameplay");
        }
        else if (context.performed && !menuOpened)
        {
            _inventoryUI.ToggleInventory(true);
            menuOpened = true;
            _inputSystemPlayerInput.SwitchCurrentActionMap("UI");
        }

        Debug.Log("toggle" + menuOpened);

        
    }

    private void Update()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y);

        _characterController.Move(move * _speed * Time.deltaTime);

        if (_isGamepad)
        {
            LookHandelerGamepad();
        }
        else
        {
            LookHandelerMouse();
        }
    }
    private void LookHandelerGamepad()
    {
        if (_lookInput.sqrMagnitude < 0.1f) return;

        Vector3 lookDirection = new Vector3(_lookInput.x, 0, _lookInput.y);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.10f);
    }

    private void LookHandelerMouse()
    {
        _lookInput = Mouse.current.position.ReadValue();

        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(_lookInput);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0;
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.10f);
        }
    }

    public void TakeDamage(float damageToTake)
    {
        hp -= damageToTake;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("HracZemrel");
        }
    }
}
