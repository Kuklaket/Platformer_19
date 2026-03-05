using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Attack = "Attack";

    private float _movementThreshold = 0.5f;
    private float _idleThreshold = 0.1f;

    public event UnityAction<float> Moving;
    public event UnityAction JumpPressed;
    public event UnityAction AttackPressed;

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis(Horizontal);

        if (Mathf.Abs(horizontalInput) > _movementThreshold)
            Moving?.Invoke(horizontalInput);
        else if (Mathf.Abs(horizontalInput) <= _idleThreshold)
            Moving?.Invoke(0f);
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown(Jump))
            JumpPressed?.Invoke();
    }

    private void HandleAttackInput()
    {
        if (Input.GetButtonDown(Attack))
            AttackPressed?.Invoke();
    }
}