using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInput playerInput = null;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 5f;
    public PlayerInput PlayerInput => playerInput;
    private void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        var inputValue = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) { return; }
    }
}
