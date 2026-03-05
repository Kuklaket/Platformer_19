using UnityEngine;

public class PlayerAnimator : BaseAnimationController
{
    public void PlayRun()
    {
        Animator.SetBool(GameConstants.AnimatorParams.IsRun, true);
        Animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        Animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
    }

    public void PlayIdle()
    {
        Animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        Animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        Animator.SetBool(GameConstants.AnimatorParams.IsIdle, true);
    }

    public void PlayJump()
    {
        Animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        Animator.SetBool(GameConstants.AnimatorParams.IsJump, true);
        Animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
    }

    public void PlayAttack()
    {
        Animator.SetTrigger(GameConstants.AnimatorParams.Attack);
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