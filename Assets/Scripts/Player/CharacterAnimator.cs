using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, true);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
    }

    public void PlayIdle()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, true);
    }

    public void PlayJump()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, true);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(GameConstants.AnimatorParams.Attack);
    }

    public void HandleMovementStateChange(bool isRunning, bool isGrounded)
    {
        if (isGrounded)
        {
            if (isRunning)
                PlayRun();
            else 
                PlayIdle();
        }
    }

    public void HandleGroundedChange(bool isGrounded, bool isRunning)
    {
        if (isGrounded)
        {
            if (isRunning)
                PlayRun();
            else
                PlayIdle();
        }
        else
        {
            PlayJump();
        }
    }
}