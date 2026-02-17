using System.Collections;
using UnityEngine;

public class EnemyAnimator : BaseAnimationController
{
    [SerializeField] private float _attackResetDelay = 0.3f;

    public void PlayAttack()
    {
        Animator.SetBool(GameConstants.AnimatorParams.IsAttack, true);
        StartCoroutine(ResetAttackAfterDelay());
    }

    private IEnumerator ResetAttackAfterDelay()
    {
        yield return new WaitForSeconds(_attackResetDelay);
        Animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }
}
