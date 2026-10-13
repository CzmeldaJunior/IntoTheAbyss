using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerInput : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField]
    private float _speed;

    private Vector2 _moveInput;
    private Vector2 _lookInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y);

        _characterController.Move(move * _speed);

        if (_lookInput.sqrMagnitude < 0.1f) return;

        Vector3 lookDirection = new Vector3(_lookInput.x, 0, _lookInput.y);
        Quaternion targetLookRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetLookRotation, 0.10f);
    }
}
