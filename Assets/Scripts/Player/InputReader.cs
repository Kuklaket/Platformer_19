using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Attack = "Attack";

    public event UnityAction<float> Moving;
    public event UnityAction JumpPressed;
    public event UnityAction AttackPressed;

    public void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        Moving?.Invoke(horizontalInput);
    }

    public void HandleJumpInput()
    {
        if (Input.GetButtonDown(Jump))
            JumpPressed?.Invoke();
    }

    public void HandleAttackInput()
    {
        if (Input.GetButtonDown(Attack))
            AttackPressed?.Invoke();
    }
}