using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField]
    private Camera _mainCamera;

    private bool _isGamepad = false;

    [SerializeField]
    private float _speed;

    private Vector2 _moveInput;
    private Vector2 _lookInput;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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
}
