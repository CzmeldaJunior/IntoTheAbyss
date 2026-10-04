using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private CharacterController _characterController;
    private Vector2 _moveInput;  

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y);

        _characterController.Move(move * _speed);
    }
}
